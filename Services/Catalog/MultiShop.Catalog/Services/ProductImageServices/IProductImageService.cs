using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Services.ProductImageServices;

public interface IProductImageService
{
    Task<List<ResultProductImageDto>> GetAllProductImageAsync();
    Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
    Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
    Task DeleteProductImageAsync(string id);
    Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
}
