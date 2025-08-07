using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductDetailController : ControllerBase
{
    private readonly IProductDetailService _ProductDetailService;

    public ProductDetailController(IProductDetailService ProductDetailService)
    {
        _ProductDetailService = ProductDetailService;
    }

    [HttpGet]
    public async Task<IActionResult> ProductDetailList()
    {
        var result = await _ProductDetailService.GetAllProductDetailAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetailById(string id)
    {
        var result = await _ProductDetailService.GetByIdProductDetailAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductDetail([FromBody] CreateProductDetailDto createProductDetailDto)
    {
        await _ProductDetailService.CreateProductDetailAsync(createProductDetailDto);
        return Ok("Ürün detayı başarıyla oluşturuldu.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        await _ProductDetailService.DeleteProductDetailAsync(id);
        return Ok("Ürün detayı başarıyla silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductDetail([FromBody] UpdateProductDetailDto updateProductDetailDto)
    {
        await _ProductDetailService.UpdateProductDetailAsync(updateProductDetailDto);
        return Ok("Ürün detayı başarıyla güncellendi.");
    }
}
