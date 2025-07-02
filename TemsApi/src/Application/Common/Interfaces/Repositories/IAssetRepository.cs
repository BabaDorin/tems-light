using Domain.Entities;

namespace Application.Common.Interfaces.Repositories;
public interface IAssetRepository
{
    Task<Guid> CreateAsync(Asset asset, CancellationToken cancellationToken);
}
