using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices;

public class ProductImageService : IProductImageService
{
    private readonly IMongoCollection<ProductImage> _ProductImageCollection;
    private readonly IMapper _mapper;

    public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _ProductImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
    {
        var value = _mapper.Map<ProductImage>(createProductImageDto);
        await _ProductImageCollection.InsertOneAsync(value);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await _ProductImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
    }

    public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
    {
        var values = await _ProductImageCollection.Find(_ => true).ToListAsync();
        var result = _mapper.Map<List<ResultProductImageDto>>(values);
        return result;
    }

    public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
    {
        var values = await _ProductImageCollection.Find(x => x.ProductImageId == id).FirstOrDefaultAsync();
        var result = _mapper.Map<GetByIdProductImageDto>(values);
        return result;
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
    {
        var value = _mapper.Map<ProductImage>(updateProductImageDto);
        await _ProductImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, value);
    }
}