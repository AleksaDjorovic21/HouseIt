using System.Text;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace HouseIt.Core.Domain;

public class Kitchen : RoomBase
{
    [SetsRequiredMembers]
    public Kitchen() { }

    [Key]
    public int Id { get; set; }
    public bool HasDiningArea { get; set; }

    public override string ToString()
    {
        var description = new StringBuilder();

        description.Append($"Kitchen: {Sqrm} sqrm, {Color} color");

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

        description.Append(HasDiningArea ? ", With dining area" : ", no dining area");

        return description.ToString();
    }
}
