using Application.Common.Models;
using Domain.Entities;

namespace Application.Validators
{
    public interface IAttributeValidator
    {
        // TODO: Switch to using Fluent result
        public Task<ValidationResult> ValidateAttributesAsync(
            AssetDefinition definition,
            CancellationToken cancellationToken);
    }
}
