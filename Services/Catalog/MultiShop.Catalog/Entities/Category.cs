using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class Category
{
    [BsonId]                                                     // bu propertynin Id olduğunu belirtir
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]        // Id benzersiz olduğunu belirtir
    public string CategoryId { get; set; }
    public string CategoryName { get; set; }
}
