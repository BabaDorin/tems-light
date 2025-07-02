namespace Domain.Entities;

public class Asset
{
    public Guid Id { get; set; } 
    public string ClientId { get; set; }
    public string TemsId { get; set; }
    public string UploadedBy { get; set; }
    public DateTime UploadedAt { get; set; }
    public DateTime PurchasedAt { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public Guid TypeId { get; set; }
    public Price Price { get; set; }
    public AssetDefinition Definition { get; set; }
}
