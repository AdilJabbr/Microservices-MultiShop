using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService discountService;

        public DiscountsController(IDiscountService discountService)
        {
            this.discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values = await discountService.GetAllDiscountCouponAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var values = await discountService.GetByIdDiscountCouponAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto dto)
        {
            await discountService.CreateDiscountCouponAsync(dto);
            return Ok("Coupon successfully created");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await discountService.DeleteDiscountCouponAsync(id);
            return Ok("The coupon was successfully deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon (UpdateDiscountCouponDto dto)
        {
            await discountService.UpdateDiscountCouponAsync(dto);
            return Ok("Discount coupon has been updated successfully");
        }

    }
}
