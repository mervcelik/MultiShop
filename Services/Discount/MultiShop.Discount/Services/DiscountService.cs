using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services;

public class DiscountService : IDiscountService
{
    private readonly DapperContext _context;

    public DiscountService(DapperContext context)
    {
        _context = context;
    }

    public async Task CreateDiscountAsync(CreateDiscountDto createCouponDto)
    {
        string query = "insert into Coupons (Code, Rate, IsActive, ValidDate) values(@code,@rate, @isActive,@validDate)";
        var parameters = new DynamicParameters();
        parameters.Add("@code", createCouponDto.Code);
        parameters.Add("@rate", createCouponDto.Rate);
        parameters.Add("@isActive", createCouponDto.IsActive);
        parameters.Add("@validDate", createCouponDto.ValidDate);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteDiscountAsync(int Id)
    {
        var query = "Delete From Coupons Where CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId",Id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultDiscountDto>> GetAllDiscountAsync()
    {
        var query = "Select * from Coupons";
        using (var connection = _context.CreateConnection())
        {
           var result =  await connection.QueryAsync<ResultDiscountDto>(query);
            return result.ToList();
        }
    }

    public async Task<GetByIdDiscountDto> GetByIdDiscountAsync(int Id)
    {
        var query = "Select * from Coupons where CouponId = @couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId", Id);
        using (var connection = _context.CreateConnection())
        {
            var result  = await connection.QueryFirstOrDefaultAsync< GetByIdDiscountDto>(query,parameters);
            return result;
        }

    }

    public async Task UpdateDiscountAsync(UpdateDiscountDto updateCouponDto)
    {
        var query = "Update Coupons set Code=@code, Rate=@rate , IsActive=@isActive, ValidDate=@validDate Where CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId", updateCouponDto.CouponId);
        parameters.Add("@code", updateCouponDto.Code);
        parameters.Add("@rate", updateCouponDto.Rate);
        parameters.Add("@isActive", updateCouponDto.IsActive);
        parameters.Add("@validDate", updateCouponDto.ValidDate);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
