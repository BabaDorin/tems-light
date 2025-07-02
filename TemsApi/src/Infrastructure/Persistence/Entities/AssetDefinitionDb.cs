using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Persistence.Entities;

public class AssetDefinitionDb
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    [BsonElement("_id")]
    public Guid Id { get; set; }

    [BsonElement("type")]
    public string Type { get; set; }

    [BsonElement("typeId")]
    public string TypeId { get; set; }

    [BsonElement("clientId")]
    public string ClientId { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }
}

