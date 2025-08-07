﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMapper _mapper;
    public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        _mapper = mapper;
    }
    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        var value = _mapper.Map<Product>(createProductDto);
        await _productCollection.InsertOneAsync(value);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _productCollection.DeleteOneAsync(x => x.ProductId == id);
    }

    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        var values = await _productCollection.Find(_ => true).ToListAsync();
        var result = _mapper.Map<List<ResultProductDto>>(values);
        return result;
    }

    public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
    {
        var values = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
        var result = _mapper.Map<GetByIdProductDto>(values);
        return result;
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        var value = _mapper.Map<Product>(updateProductDto);
        await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, value);
    }
}
