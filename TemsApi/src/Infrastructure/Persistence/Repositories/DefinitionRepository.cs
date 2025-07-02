using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Mapping;
using Infrastructure.Persistence.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Persistence.Repositories;

public class DefinitionRepository : IDefinitionRepository
{
    private readonly IMongoCollection<AssetDefinitionDb> _definitions;
    public DefinitionRepository(IMongoClient client, IConfiguration configuration)
    {
        var database = client.GetDatabase(configuration.GetSection("DatabaseSettings:DatabaseName").Value);
        _definitions = database.GetCollection<AssetDefinitionDb>(configuration.GetSection("DatabaseSettings:Collections:AssetDefinition").Value);
    }
    public async Task<Guid> CreateAsync(AssetDefinition assetDefinition, CancellationToken cancellationToken)
    {
        assetDefinition.Id = Guid.NewGuid();

        AssetDefinitionDb definition = Mapper.MapToDb(assetDefinition);

        await _definitions.InsertOneAsync(definition,cancellationToken);

        return definition.Id;
    }

    public async Task<AssetDefinition> FindByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var filter = Builders<AssetDefinitionDb>.Filter.Eq("_id", id.ToString());

        var definition = await(await _definitions.FindAsync(filter, cancellationToken: cancellationToken))
            .FirstOrDefaultAsync();

        return Mapper.MapToEntity(definition);
    }
}

