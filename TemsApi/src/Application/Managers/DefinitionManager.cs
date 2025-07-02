using Application.Common.Interfaces.Managers;
using Application.Common.Interfaces.Repositories;
using Application.Validators;
using Domain.Entities;
using FluentResults;

namespace Application.Managers;
public class DefinitionManager : IDefinitionManager
{
    private readonly IDefinitionRepository _definitionRepository;
    private readonly IAttributeValidator _attributeValidator;

    public DefinitionManager(
        IDefinitionRepository definitionRepository,
        IAttributeValidator attributeValidator)
    {
        _definitionRepository = definitionRepository;
        _attributeValidator = attributeValidator;
    }

    public async Task<Result<Guid>> CreateAsync(AssetDefinition assetDefinition, CancellationToken cancellationToken)
    {
        var validationResult = await _attributeValidator.ValidateAttributesAsync(assetDefinition, cancellationToken);

        if(!validationResult.IsValid)
            return Result.Fail<Guid>(validationResult.ErrorMessage);

        var definitionId = await _definitionRepository.CreateAsync(assetDefinition, cancellationToken);

        return Result.Ok<Guid>(definitionId);
    }
}
