using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services;

public interface IDiscountService
{
    Task<List<ResultDiscountDto>> GetAllDiscountAsync();
    Task UpdateDiscountAsync(UpdateDiscountDto updateCouponDto);
    Task CreateDiscountAsync(CreateDiscountDto createCouponDto);
    Task DeleteDiscountAsync(int Id);
    Task<GetByIdDiscountDto> GetByIdDiscountAsync(int Id);
}
