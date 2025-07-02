using MongoDB.Bson;
using System.Text.RegularExpressions;

namespace Infrastructure.Helpers;

public static class MongoDbQuerying
{
    public static Func<string, BsonRegularExpression> CaseInsensitiveCompare = (field) =>
        BsonRegularExpression.Create(new Regex(field, RegexOptions.IgnoreCase));
}

