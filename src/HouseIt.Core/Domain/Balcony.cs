using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HouseIt.Core.Domain;

[method: SetsRequiredMembers]
public class Balcony(BalconySize size, BalconyType type)
{
    [Key]
    public int Id { get; set; }
    public required BalconySize Size { get; set; } = size;
    public required BalconyType Type { get; set; } = type;

    public override string ToString()
    {
        return $"Balcony: {Size} {Type} ";
    }
}
