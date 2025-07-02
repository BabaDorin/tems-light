using Domain.Enums;

namespace Domain.Entities;

public class AttributeMetadata
{
    public string Name { get; set; }
    public DataType DataType { get; set; }
    public bool IsRequired { get; set; }
}
