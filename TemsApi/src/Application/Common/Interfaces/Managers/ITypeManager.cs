using Domain.Entities;
using FluentResults;

namespace Application.Common.Interfaces.Managers;
public interface ITypeManager
{
    Task<Result<Guid>> CreateAsync(AssetType assetType, CancellationToken cancellationToken);
}
