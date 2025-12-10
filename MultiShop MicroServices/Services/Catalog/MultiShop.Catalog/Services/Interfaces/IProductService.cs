using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto dto);
        Task UpdateProductAsync(UpdateProductDto dto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
    }
}
