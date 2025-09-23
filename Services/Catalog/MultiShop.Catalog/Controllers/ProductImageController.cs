using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductImageController : ControllerBase
{
    private readonly IProductImageService _ProductImageService;

    public ProductImageController(IProductImageService ProductImageService)
    {
        _ProductImageService = ProductImageService;
    }

    [HttpGet]
    public async Task<IActionResult> ProductImageList()
    {
        var result = await _ProductImageService.GetAllProductImageAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductImageById(string id)
    {
        var result = await _ProductImageService.GetByIdProductImageAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductImage([FromBody] CreateProductImageDto createProductImageDto)
    {
        await _ProductImageService.CreateProductImageAsync(createProductImageDto);
        return Ok("Ürün detayı başarıyla oluşturuldu.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductImage(string id)
    {
        await _ProductImageService.DeleteProductImageAsync(id);
        return Ok("Ürün detayı başarıyla silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductImage([FromBody] UpdateProductImageDto updateProductImageDto)
    {
        await _ProductImageService.UpdateProductImageAsync(updateProductImageDto);
        return Ok("Ürün detayı başarıyla güncellendi.");
    }
}
