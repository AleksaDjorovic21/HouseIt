using System.Text;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace HouseIt.Core.Domain;

public class Room : RoomBase
{
    [SetsRequiredMembers]
    public Room() { }

    [Key]
    public int Id { get; set; }
    public required RoomTypes RoomType { get; set; }
    public bool HasBalcony => Balcony != null;
    public Balcony? Balcony { get; set; }

    public override string ToString()
    {
        var description = new StringBuilder();

        description.Append($"{RoomType}: {Sqrm} sqrm, {Color} color");

        string doorDescription = GenerateDoorDescription();
        string windowDescription = GenerateWindowDescription();

        if (!string.IsNullOrEmpty(doorDescription))
        {
            description.Append($", {doorDescription}");
        }

        if (!string.IsNullOrEmpty(windowDescription))
        {
            description.Append($", {windowDescription}");
        }

        if (HasBalcony)
        {
            description.Append($", {Balcony}");
        }
        else
        {
            description.Append(", No balcony");
        }

        return description.ToString();
    }
}






