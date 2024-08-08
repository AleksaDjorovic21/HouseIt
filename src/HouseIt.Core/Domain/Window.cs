using System.Diagnostics.CodeAnalysis;

namespace HouseIt.Core.Domain;

[method: SetsRequiredMembers]
public class Window(WindowSizes size)
{
    public required WindowSizes Size { get; set; } = size;
}
