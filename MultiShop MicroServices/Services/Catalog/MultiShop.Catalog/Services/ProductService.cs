using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.Interfaces;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<Product> collection;

        public ProductService(IMapper mapper , IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient( databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            collection = database.GetCollection<Product>(databaseSettings.ProductColletionName);
            this.mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto dto)
        {
                var values = mapper.Map<Product>(dto);
            await collection.InsertOneAsync(values);
        }
    
        public async Task DeleteProductAsync(string id) => await collection.DeleteOneAsync(x => x.ProductId == id);

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await collection.Find(x=> true ).ToListAsync();
            return mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await collection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            return mapper.Map<GetByIdProductDto>(value);
        }

        public async Task UpdateProductAsync(UpdateProductDto dto)
        {
            var values = mapper.Map<Product>(dto);
            await collection.FindOneAndReplaceAsync(x=>x.ProductId == dto.ProductId , values);
        }
    }
}
