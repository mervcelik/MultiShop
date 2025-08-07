using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices;

public class ProductDetailService : IProductDetailService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<ProductDetail> _productDetailCollection;
    public ProductDetailService(IMapper mapper,IDatabaseSettings databaseSettings)
    {
       _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
    }
    public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
    {
        var value = _mapper.Map<ProductDetail>(createProductDetailDto);
        await _productDetailCollection.InsertOneAsync(value);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailId == id);
    }

    public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
    {
        var values = await _productDetailCollection.Find(_ => true).ToListAsync();
        var result = _mapper.Map<List<ResultProductDetailDto>>(values);
        return result;
    }

    public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
    {
        var values = await _productDetailCollection.Find(x => x.ProductDetailId == id).FirstOrDefaultAsync();
        var result = _mapper.Map<GetByIdProductDetailDto>(values);
        return result;
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        var value = _mapper.Map<ProductDetail>(updateProductDetailDto);
        await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, value);
    }
}
