using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using Application.Validators.AttributeValidatorFactory;
using Domain.Entities;

namespace Application.Validators
{
    public class AttributesValidator : IAttributeValidator
    {
        private readonly ITypeRepository typeRepository;
        private readonly IAttributeValidatorFactory validatorFactory;

        public AttributesValidator(ITypeRepository typeRepository,
            IAttributeValidatorFactory validatorFactory)
        {
            this.typeRepository = typeRepository;
            this.validatorFactory = validatorFactory;
        }

        public async Task<ValidationResult> ValidateAttributesAsync(
            AssetDefinition definition,
            CancellationToken cancellationToken)
        {
            var correspondingType = await typeRepository
                .FindByIdAsync(Guid.Parse(definition.TypeId), cancellationToken);

            var attributesMetadata = correspondingType.Attributes;

            foreach (var attribute in definition.Attributes)
            {
                var metaData = correspondingType
                    .Attributes
                    .FirstOrDefault(a => a.Name == attribute.AttributeName);

                if (metaData == null)
                {
                    continue;
                }

                if (metaData.IsRequired && string.IsNullOrWhiteSpace(attribute.Value))
                {
                    return ValidationResult
                        .Failed($"A value for {attribute.AttributeName} is required.");
                }

                var validator = validatorFactory.PickStrategy(metaData);
                var validationResult = validator.Validate(attribute, metaData);

                if (!validationResult.IsValid)
                    return validationResult;
            }

            return ValidationResult.Success();
        }
    }
}
