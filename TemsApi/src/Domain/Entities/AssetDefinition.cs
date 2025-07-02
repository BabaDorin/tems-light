namespace Domain.Entities;

public class AssetDefinition
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string TypeId { get; set; }
    public string ClientId { get; set; }
    public string Name { get; set; }
    public List<Attribute> Attributes { get; set; }
}


