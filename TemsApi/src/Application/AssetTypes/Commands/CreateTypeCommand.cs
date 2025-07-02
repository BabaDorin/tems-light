using Application.Common.Interfaces.Managers;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.AssetTypes.Commands;

public record CreateTypeCommand(AssetType assetType) : IRequest<Result<Guid>>;

public class CreateTypeCommandHandler : IRequestHandler<CreateTypeCommand, Result<Guid>>
{
    private readonly ITypeManager _typeManager;
    public CreateTypeCommandHandler(ITypeManager typeManager)
    {
        _typeManager = typeManager;
    }
    public async Task<Result<Guid>> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
    {
        var createdType = await _typeManager.CreateAsync(request.assetType, cancellationToken);

        return createdType;
    }
}

