using Application.Common.Interfaces.Managers;
using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using FluentResults;

namespace Application.Managers;

public class AssetManager : IAssetManager
{
    private readonly IAssetRepository _assetRepository;
    private readonly IDefinitionRepository _definitionRepository;
    private readonly ITypeRepository _typeRepository;
    public AssetManager(
        IAssetRepository assetRepository,
        IDefinitionRepository definitionRepository,
        ITypeRepository typeRepository)
    {
        _assetRepository = assetRepository;
        _definitionRepository = definitionRepository;
        _typeRepository = typeRepository;
    }
    public async Task<Result<Guid>> CreateAsync(Asset asset, CancellationToken cancellationToken)
    {
        var existingType = await _typeRepository.FindByIdAsync(asset.TypeId, cancellationToken);
        var existingDefinition = await _definitionRepository.FindByIdAsync(asset.Definition.Id, cancellationToken);

        if (existingType is null || 
            existingDefinition is null)
            return Result.Fail("The asset type or asset definition doesn't exist!");

        var createdAsset = await _assetRepository.CreateAsync(asset, cancellationToken);

        return Result.Ok<Guid>(createdAsset);
    }
}
