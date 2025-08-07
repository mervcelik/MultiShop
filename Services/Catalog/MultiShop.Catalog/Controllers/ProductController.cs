using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _ProductService;

    public ProductController(IProductService ProductService)
    {
        _ProductService = ProductService;
    }

    [HttpGet]
    public async Task<IActionResult> ProductList()
    {
        var result = await _ProductService.GetAllProductAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var result = await _ProductService.GetByIdProductAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProductDto)
    {
        await _ProductService.CreateProductAsync(createProductDto);
        return Ok("Ürün başarıyla oluşturuldu.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _ProductService.DeleteProductAsync(id);
        return Ok("Ürün başarıyla silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto updateProductDto)
    {
        await _ProductService.UpdateProductAsync(updateProductDto);
        return Ok("Ürün başarıyla güncellendi.");
    }
}
