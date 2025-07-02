using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Persistence.Entities;

public class AttributeDb
{
    [BsonElement("attributeName")]
    public string AttributeName { get; set; }

    [BsonElement("value")]
    public string Value { get; set; }
}

