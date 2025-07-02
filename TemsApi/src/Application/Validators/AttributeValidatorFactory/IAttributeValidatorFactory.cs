using Application.Validators.AttributeValidationStrategies;
using Domain.Entities;

namespace Application.Validators.AttributeValidatorFactory
{
    public interface IAttributeValidatorFactory
    {
        public IAttributeValidationStrategy PickStrategy(AttributeMetadata metadata);
    }
}
