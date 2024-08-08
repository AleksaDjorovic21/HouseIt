using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HouseIt.Core.Domain;

public class DesignRequest
{
    [Key]
    public int Id { get; set; }
    public string Name { get; init; }
    public ICollection<Floor> Floors { get; set;} = [];

    public DesignRequest(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");
        }
        Name = name;
    }

    public bool IsEmpty()
    {
        return Floors.Count == 0;
    }

    public override string ToString()
    {
        if (IsEmpty())
        {
            return "Your request is empty";
        }

        StringBuilder sb = new();

        sb.AppendLine($"Request name: {Name}");
        sb.AppendLine($"Number of Floors: {Floors.Count}");

        int floorIndex = 1;
        foreach (var floor in Floors)
        {
            sb.AppendLine($"------------------------");
            sb.AppendLine($"{OrdinalUtility.ConvertToOrdinal(floorIndex++)} Floor");
            sb.AppendLine($"*******************");

            sb.AppendLine("Rooms:");

            foreach (var room in floor.Rooms)
            {
                sb.AppendLine(room.ToString());
            }

            sb.AppendLine("------------------------");

            foreach (var kitchen in floor.Kitchens)
            {
                sb.AppendLine(kitchen.ToString());
            }

            foreach (var toilet in floor.Toilets)
            {
                sb.AppendLine(toilet.ToString());
            }
        }

        return sb.ToString();
    }
}
