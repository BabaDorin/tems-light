using Application.Common.Models;
using Domain.Entities;

namespace Application.Validators.AttributeValidationStrategies
{
    public class StringValidator : IAttributeValidationStrategy
    {
        public ValidationResult Validate(
            Domain.Entities.Attribute attribute,
            AttributeMetadata metadata)
        {
            // validate if string
            // Actually We don't have to add any validation logic here for now.
            // We'll need it later when we will add other constraints like minLength, maxLength etc.

            return ValidationResult.Success();
        }
    }
}
