using Domain.Entities;
using FluentResults;

namespace Application.Common.Interfaces.Managers;
public interface IAssetManager
{
    Task<Result<Guid>> CreateAsync(Asset asset, CancellationToken cancellationToken);
}
