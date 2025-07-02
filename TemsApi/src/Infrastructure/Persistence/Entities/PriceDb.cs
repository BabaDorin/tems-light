using Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Persistence.Entities;

public class PriceDb
{
    [BsonElement("amount")]
    public double Amount { get; set; }

    [BsonElement("currency")]
    public Currency Currency { get; set; }
}

