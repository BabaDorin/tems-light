using Application.Common.Interfaces.Managers;
using Domain.Entities;
using FluentResults;
using MediatR;

namespace Application.AssetDefinitions.Commands;
public record CreateDefinitionCommand(AssetDefinition AssetDefinition) : IRequest<Result<Guid>>;

public class CreateDefinitionCommandHandler : IRequestHandler<CreateDefinitionCommand, Result<Guid>>
{
    private readonly IDefinitionManager _definitionManager;

    public CreateDefinitionCommandHandler(IDefinitionManager definitionManager)
    {
        _definitionManager = definitionManager;
    }

    public async Task<Result<Guid>> Handle(CreateDefinitionCommand request, CancellationToken cancellationToken)
    {
        var result = await _definitionManager.CreateAsync(request.AssetDefinition, cancellationToken);

        return result;
    }
}
