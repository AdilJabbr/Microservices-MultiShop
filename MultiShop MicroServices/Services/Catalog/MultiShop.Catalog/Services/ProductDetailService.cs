
using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.Interfaces;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> collection;
        private readonly IMapper mapper;
        public ProductDetailService(IMapper _mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            collection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            mapper = _mapper;
        }
        public async Task CreateProductDetailAsync(CreateProductDetailDto dto)
        {
            var value = mapper.Map<ProductDetail>(dto);
            await collection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await collection.DeleteOneAsync(x => x.ProductDetailId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await collection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var value = await collection.Find<ProductDetail>(x => x.ProductDetailId == id).FirstOrDefaultAsync();

            return mapper.Map<GetByIdProductDetailDto>(value);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto dto)
        {
            var values = mapper.Map<ProductDetail>(dto);
            await collection.FindOneAndReplaceAsync(x => x.ProductDetailId == dto.ProductDetailId, values);
        }
    }
}
