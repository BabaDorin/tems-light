using Application.Validators.AttributeValidationStrategies;
using Domain.Entities;
using Domain.Enums;

namespace Application.Validators.AttributeValidatorFactory
{
    public class AttributeValidatorFactory : IAttributeValidatorFactory
    {
        public IAttributeValidationStrategy PickStrategy(AttributeMetadata metadata)
        {
            if (metadata.DataType == DataType.Text)
            {
                return new StringValidator();
            }

            if (metadata.DataType == DataType.Number)
            {
                // TODO: Return number validator
                return new NumberValidator();
            }

            throw new Exception("Validator not declared for the provided attribute metadata");
        }
    }
}
