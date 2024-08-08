using System.Text;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace HouseIt.Core.Domain;

public class Toilet : RoomBase
{
    [SetsRequiredMembers]
    public Toilet() { }

    [Key]
    public int Id { get; set; }
    public required ToiletTypes ToiletType { get; set; }

    public override string ToString()
    {
        var description = new StringBuilder();

        description.Append($"Toilet: {ToiletType}, {Sqrm} sqrm, {Color} color");

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

        return description.ToString();
    }
}

