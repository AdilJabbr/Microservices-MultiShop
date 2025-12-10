using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.Interfaces;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> collection;
        private readonly IMapper mapper;
        public ProductImageService(IMapper _mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            collection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            mapper = _mapper;
        }
        public async Task CreateProductImageAsync(CreateProductImageDto dto)
        {
            var value = mapper.Map<ProductImage>(dto);
            await collection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await collection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await collection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var value = await collection.Find<ProductImage>(x => x.ProductImageId == id).FirstOrDefaultAsync();

            return mapper.Map<GetByIdProductImageDto>(value);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto dto)
        {
            var values = mapper.Map<ProductImage>(dto);
            await collection.FindOneAndReplaceAsync(x => x.ProductImageId == dto.ProductImageId, values);
        }
    }
}
