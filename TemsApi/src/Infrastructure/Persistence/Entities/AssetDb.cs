using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Persistence.Entities;

public class AssetDb
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    [BsonElement("_id")]
    public Guid Id { get; set; }

    [BsonElement("clientId")]
    public string ClientId { get; set; }

    [BsonElement("temsId")]
    public string TemsId { get; set; }

    [BsonRepresentation(BsonType.String)]
    [BsonElement("uploadedBy")]
    public string UploadedBy { get; set; }

    [BsonRepresentation(BsonType.String)]
    [BsonElement("uploadedAt")]
    public DateTime UploadedAt { get; set; }

    [BsonRepresentation(BsonType.String)]
    [BsonElement("purchasedAt")]
    public DateTime PurchasedAt { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("type")]
    public string Type { get; set; }

    [BsonRepresentation(BsonType.String)]
    [BsonElement("typeId")]
    public Guid TypeId { get; set; }

    [BsonElement("price")]
    public PriceDb Price { get; set; }

    [BsonElement("definition")]
    public AssetDefinitionDb Definition { get; set; }
}

