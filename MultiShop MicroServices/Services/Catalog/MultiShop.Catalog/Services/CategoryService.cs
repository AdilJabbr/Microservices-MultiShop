using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.Interfaces;
using MultiShop.Catalog.Settings;
using System.Net.Sockets;
using static MongoDB.Driver.WriteConcern;

namespace MultiShop.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> collection;
        private readonly IMapper mapper; 
        public CategoryService(IMapper _mapper , IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            collection = database.GetCollection<Category>(databaseSettings.CategoryColletionName);
            mapper = _mapper;
        }
        public async Task CreateCategoryAsync(CreateCategoryDto dto)
        {
            var value = mapper.Map<Category>(dto);
             await collection.InsertOneAsync(value);
        }
            
        public async Task DeleteCategoryAsync(string id)
        {
            await collection.DeleteOneAsync(x=>x.CategoryId==id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await collection.Find(x=> true).ToListAsync();
            return mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var value = await collection.Find<Category>(x => x.CategoryId == id).FirstOrDefaultAsync();

            return mapper.Map<GetByIdCategoryDto>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto dto)
        {
            var values = mapper.Map<Category>(dto);
            await collection.FindOneAndReplaceAsync(x=>x.CategoryId == dto.CategoryId, values);
        }
    }
}


//DevOps
//14.10.2025
//Responsibilities

//• Design and manage CI/CD pipelines using tools like Azure DevOps or Jenkins.
//• Containerize services such as Redis using Docker and orchestrate with Kubernetes.
//• Automate infrastructure with Terraform, ARM Templates, Bicep or other IaC tools.
//• Implement and manage service discovery, traffic management, and security for inter-service communication, potentially using service mesh technologies.
//• Deploy, configure, and manage secret management systems like HashiCorp Vault or Azure Key Vault to ensure secure handling of credentials and sensitive data.
//• Set up and maintain production-ready datastore clusters, with a focus on Redis (persistence, replication, high availability) and SQL Server.
//• Build secure, scalable, and observable environments for staging and production.
//• Create health monitoring, logging, and alerting systems (e.g., ELK, Grafana, Prometheus).
//• Collaborate with developers to streamline deployments and solve environment issues.
//• Maintain clear documentation for deployment processes and incident response with Confluence, draw.io, MD, etc.

//Tech Stack

//• Cloud: Azure(preferred), AWS
//• Containers: Docker, Kubernetes
//• CI/CD: Azure DevOps, GitHub Actions, Jenkins
//• IaC: Terraform, Bicep, ARM
//• Secrets: HashiCorp Vault, Azure Key Vault
//• Monitoring: Grafana, Prometheus, ELK
//• Datastores: Redis, SQL Server

//Requirements

//• 2+ years of experience in a DevOps, Site Reliability (SRE) or Platform Engineering role.
//• Proven experience designing, building, and operating infrastructure for microservices-based applications.
//• Strong hands-on experience with containerization (Docker) and orchestration (Kubernetes) in a production environment.
//• Proficiency with at least one Infrastructure as Code (IaC) tool (Terraform is highly preferred).
//• Solid experience with CI/CD tools (Azure DevOps preferred).
//• Practical experience managing Redis clusters in a production setting (setup, monitoring, troubleshooting).
//• Solid scripting knowledge (PowerShell, Bash, or Python).
//• Deep understanding of secure credential handling and hands-on experience with secret management tools (Vault, Azure Key Vault).
//• Solid understanding of networking concepts (TCP/IP, DNS, HTTP, firewalls) and security best practices in the cloud.
//• Familiarity with system administration.
//• Adaptability and ability to work effectively in a team environment.
//• Language skills: Fluency in Azerbaijani, English (B2), Russian (B2).

//Nice to Have

//• Experience supporting .NET application infrastructure.
//• Hands-on experience with API Gateways (e.g., Azure API Management, Kong) and/or Service Mesh technologies (e.g., Istio, Linkerd).
//• Experience with Identity and Access Management (IAM) solutions, particularly Keycloak.
//• Relevant cloud or Kubernetes certifications (e.g., Azure DevOps Engineer Expert, Certified Kubernetes Administrator - CKA).
//• Experience with database automation and backup strategies.


//Şirkətinizdə Junior Backend Developer vəzifəsinə müraciət edirəm. C# , ASP.NET Core və SQL ilə bağlı təcrübəm var . Kod səliqəsinə və optimizasiyaya fikir verirəm , Mvc və Api təcrübəm var ancaq mikroservisdə sadəcə nəzəri biliyə sahibəm .
//İnanıram ki, bacarıqlarım komandanıza faydalı ola bilərəm . Müraciətimi nəzərdən keçirdiyiniz üçün təşəkkür edirəm.