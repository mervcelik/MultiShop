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
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountList()
        {
            var result = await _discountService.GetAllDiscountAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountById(int id)
        {
            var result = await _discountService.GetByIdDiscountAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount([FromBody] CreateDiscountDto createCouponDto)
        {
            await _discountService.CreateDiscountAsync(createCouponDto);
            return Ok("Kupon başarıyla oluşturuldu.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            await _discountService.DeleteDiscountAsync(id);
            return Ok("Kupon başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscount([FromBody] UpdateDiscountDto updateCouponDto)
        {
            await _discountService.UpdateDiscountAsync(updateCouponDto);
            return Ok("Kupon başarıyla güncellendi.");
        }
    }
}
