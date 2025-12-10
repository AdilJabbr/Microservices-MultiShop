using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.Interfaces;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            this.productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await productDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var value = await productDetailService.GetByIdProductDetailAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto dto)
        {
            await productDetailService.CreateProductDetailAsync(dto);
            return Ok("ProductDetail is successfully created");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await productDetailService.DeleteProductDetailAsync(id);
            return Ok("ProductDetail is successfully deleted");
        }

        [HttpPut]
        public async Task<IActionResult> CreateProductDetail(UpdateProductDetailDto dto)
        {
            await productDetailService.UpdateProductDetailAsync(dto);
            return Ok("ProductDetail is successfully updated");
        }
    }
}
