using System.Diagnostics.CodeAnalysis;

namespace HouseIt.Core.Domain;

[method: SetsRequiredMembers]
public class Door(DoorType type, ColorPalette color)
{
    public required DoorType Type { get; set; } = type;
    public required ColorPalette Color { get; set; } = color;
}

