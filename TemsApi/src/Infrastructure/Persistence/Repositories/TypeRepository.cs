using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Helpers;
using Infrastructure.Mapping;
using Infrastructure.Persistence.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Persistence.Repositories;

public class TypeRepository : ITypeRepository
{
    private readonly IMongoCollection<AssetTypeDb> _types;
    public TypeRepository(IMongoClient client, IConfiguration configuration)
    {
        var database = client.GetDatabase(configuration.GetSection("DatabaseSettings:DatabaseName").Value);
        _types = database.GetCollection<AssetTypeDb>(configuration.GetSection("DatabaseSettings:Collections:AssetType").Value);
    }

    public async Task<Guid> CreateAsync(AssetType assetType, CancellationToken cancellationToken)
    {
        assetType.Id = Guid.NewGuid();

        AssetTypeDb type = Mapper.MapToDb(assetType);

        await _types.InsertOneAsync(type, cancellationToken: cancellationToken);

        return type.Id;
    }

    public async Task<AssetType> FindByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var filter = Builders<AssetTypeDb>.Filter.Eq("_id", id.ToString());

        var type = await(await _types.FindAsync(filter, cancellationToken: cancellationToken))
            .FirstOrDefaultAsync(cancellationToken);

        return Mapper.MapToEntity(type);
    }

    public async Task<IEnumerable<AssetType>> FindByNameAsync(string name, CancellationToken cancellationToken)
    {
        var filter = Builders<AssetTypeDb>.Filter.Eq("name", MongoDbQuerying.CaseInsensitiveCompare(name));

        var matches = await (await _types.FindAsync(filter, cancellationToken: cancellationToken))
            .ToListAsync(cancellationToken);

        return matches.Select(type => Mapper.MapToEntity(type)).ToList();
    }
}

