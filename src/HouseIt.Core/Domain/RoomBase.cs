namespace HouseIt.Core.Domain;

public abstract class RoomBase
{
    public required int Sqrm { get; set; }
    public required ColorPalette Color { get; set; }
    public ICollection<Door> Doors { get; set; } = [];
    public ICollection<Window> Windows { get; set; } = [];

    protected string GenerateDoorDescription()
    {
        if (Doors.Count == 0)
        {
            return "No doors";
        }

        var groupedDoors = Doors.GroupBy(d => new { d.Type, d.Color });
        var descriptions = groupedDoors.Select(g => $"{g.Count()} {g.Key.Type} door{(g.Count() != 1 ? "s" : "")} ({g.Key.Color})");
        return string.Join(", ", descriptions);
    }

    protected string GenerateWindowDescription()
    {
        if (Windows.Count == 0)
        {
            return "No windows";
        }

        var windowSizes = Windows.Select(w => w.Size).Distinct().ToList();
        if (windowSizes.Count == 1)
        {
            return $"{Windows.Count} {windowSizes[0]} window{(Windows.Count != 1 ? "s" : "")}";
        }

        var descriptions = windowSizes.Select(size => $"{Windows.Count(w => w.Size == size)} {size} window{(Windows.Count(w => w.Size == size) != 1 ? "s" : "")}");
        return string.Join(", ", descriptions);
    }
}

