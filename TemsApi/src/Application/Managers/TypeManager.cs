using Application.Common.Interfaces.Managers;
using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using FluentResults;

namespace Application.Managers;

public class TypeManager : ITypeManager
{
    private readonly ITypeRepository _typeRepository;
    public TypeManager(ITypeRepository typeRepository)
    {
        _typeRepository = typeRepository;
    }
    public async Task<Result<Guid>> CreateAsync(AssetType assetType, CancellationToken cancellationToken)
    {
        var existingTypes = await _typeRepository.FindByNameAsync(assetType.Name, cancellationToken);

        if (existingTypes.Any())
            return Result.Fail<Guid>("This type already exist!");

        var typeId = await _typeRepository.CreateAsync(assetType, cancellationToken);

        return Result.Ok<Guid>(typeId);
    }
}


