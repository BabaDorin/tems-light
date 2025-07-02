using Application.Common.Models;
using Domain.Entities;

namespace Application.Validators.AttributeValidationStrategies
{
    public interface IAttributeValidationStrategy
    {
        public ValidationResult Validate(
            Domain.Entities.Attribute attribute,
            AttributeMetadata metadata);
    }
}
