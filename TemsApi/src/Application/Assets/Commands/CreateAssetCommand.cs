using Application.Common.Interfaces.Managers;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.Assets.Commands;
public record CreateAssetCommand(Asset Asset) : IRequest<Result<Guid>>;

public class CreateAssetCommandHandler : IRequestHandler<CreateAssetCommand, Result<Guid>>
{
    private readonly IAssetManager _assetManager;

    public CreateAssetCommandHandler(IAssetManager assetManager)
    {
        _assetManager = assetManager;
    }

    public async Task<Result<Guid>> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
    {
        var createdAsset = await _assetManager.CreateAsync(request.Asset, cancellationToken);

        return createdAsset;
    }
}
