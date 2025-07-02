
using Domain.Entities;
using Infrastructure.Persistence.Entities;

namespace Infrastructure.Mapping;

public class Mapper
{
    public static AssetDb MapToDb(Asset asset)
    {
        return new AssetDb
        {
            Id = asset.Id,
            ClientId = asset.ClientId,
            TemsId = asset.TemsId,
            UploadedBy = asset.UploadedBy,
            UploadedAt = asset.UploadedAt,
            PurchasedAt = asset.PurchasedAt,
            Description = asset.Description,
            Type = asset.Type,
            TypeId = asset.TypeId,
            Price = MapToDb(asset.Price),
            Definition = MapToDb(asset.Definition),
        };
    }
    public static AssetDefinitionDb MapToDb(AssetDefinition definition)
    {
        return new AssetDefinitionDb
        {
            Id = definition.Id,
            Type = definition.Type,
            TypeId = definition.TypeId,
            ClientId = definition.ClientId,
            Name = definition.Name
        };
    }
    public static AssetTypeDb MapToDb(AssetType type)
    {
        return new AssetTypeDb
        {
            Id = type.Id,
            ClientId = type.ClientId,
            Name = type.Name,
            Attributes = type.Attributes.Select(a => MapToDb(a)).ToList(),
        };
    }
    private static PriceDb MapToDb(Price price)
    {
        return new PriceDb
        {
            Amount = price.Amount,
            Currency = price.Currency
        };
    }
    public static AttributeMetadataDb MapToDb(AttributeMetadata attributeMetadata)
    {
        return new AttributeMetadataDb
        {
            Name = attributeMetadata.Name,
            DataType = attributeMetadata.DataType,
            IsRequired = attributeMetadata.IsRequired
        };
    }

    // Mapping to entity
    public static AssetType MapToEntity(AssetTypeDb type)
    {
        return new AssetType
        {
            Id = type.Id,
            ClientId = type.ClientId,
            Name = type.Name,
            Attributes = type.Attributes.Select(a => MapToEntity(a)).ToList(),
        };
    }
    public static AssetDefinition MapToEntity(AssetDefinitionDb definitionDb)
    {
        return new AssetDefinition
        {
            Id = definitionDb.Id,
            Type = definitionDb.Type,
            TypeId = definitionDb.TypeId,
            ClientId = definitionDb.ClientId,
            Name = definitionDb.Name,
        };
    }
    public static AttributeMetadata MapToEntity(AttributeMetadataDb attributeMetadata)
    {
        return new AttributeMetadata
        {
            Name = attributeMetadata.Name,
            DataType = attributeMetadata.DataType,
            IsRequired = attributeMetadata.IsRequired
        };
    }
}

