using Domain.Entities;

namespace Application.Common.Interfaces.Repositories;

public interface ITypeRepository
{
    Task<Guid> CreateAsync(AssetType assetType, CancellationToken cancellationToken);
    Task<IEnumerable<AssetType>> FindByNameAsync(string name, CancellationToken cancellationToken);
    Task<AssetType> FindByIdAsync(Guid id, CancellationToken cancellationToken);
}

