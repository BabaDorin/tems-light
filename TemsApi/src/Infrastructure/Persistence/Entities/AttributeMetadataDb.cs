using Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Persistence.Entities;

public class AttributeMetadataDb
{
    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("dataType")]
    public DataType DataType { get; set; }

    [BsonElement("isRequired")]
    public bool IsRequired { get; set; }
}

