using Domain.Entities;
using FluentResults;

namespace Application.Common.Interfaces.Managers;
public interface IDefinitionManager
{
    Task<Result<Guid>> CreateAsync(AssetDefinition assetDefinition, CancellationToken cancellationToken);
}
