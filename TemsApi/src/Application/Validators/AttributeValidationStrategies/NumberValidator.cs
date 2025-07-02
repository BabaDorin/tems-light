using Application.Common.Models;
using Domain.Entities;
using Domain.Enums;

namespace Application.Validators.AttributeValidationStrategies;
public class NumberValidator : IAttributeValidationStrategy
{
    public ValidationResult Validate(Domain.Entities.Attribute attribute, AttributeMetadata metadata)
    {
        return double.TryParse(attribute.Value, out double _) ?
            ValidationResult.Success() :
            ValidationResult.Failed("The value must be a number!");
    }
}
