namespace MultiShop.Catalog.Settings;

public class DatabaseSettings : IDatabaseSettings
{
    public string CategoryCollectionName { get; set; } = "Categories";
    public string ProductCollectionName { get; set; } = "Products";
    public string ProductDetailCollectionName { get; set; } = "ProductDetails";
    public string ProductImageCollectionName { get; set; } = "ProductImages";
    public string ConnectionString { get; set; } = "mongodb://localhost:27017";
    public string DatabaseName { get; set; } = "MultiShopCatalogDb";
}