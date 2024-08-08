using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HouseIt.Core.Domain;

public class Floor
{
    [Key]
    public int Id { get; set; }
    public ICollection<Room> Rooms { get; set; } = [];
    public ICollection<Kitchen> Kitchens { get; set; } = [];
    public ICollection<Toilet> Toilets { get; set; } = [];
    public int RoomCount => Rooms.Count;

    public Room AddRoom(Room room)
    {
        Rooms.Add(room);
        return room;
    }

    public Kitchen AddKitchen(Kitchen kitchen)
    {
        Kitchens.Add(kitchen);
        return kitchen;
    }

    public Toilet AddToilet(Toilet toilet)
    {
        Toilets.Add(toilet);
        return toilet;
    }

    public override string ToString()
    {
        StringBuilder sb = new();

        sb.AppendLine("Rooms:");
        foreach (var room in Rooms)
        {
            sb.AppendLine($"...{room.ToString()}");
        }

        return sb.ToString();
    }
}
