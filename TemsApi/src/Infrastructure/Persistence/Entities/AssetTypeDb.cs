using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Persistence.Entities;

public class AssetTypeDb
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    [BsonElement("_id")]
    public Guid Id { get; set; }

    [BsonElement("clientId")]
    public string ClientId { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("attributes")]
    public List<AttributeMetadataDb> Attributes { get; set; }
}

