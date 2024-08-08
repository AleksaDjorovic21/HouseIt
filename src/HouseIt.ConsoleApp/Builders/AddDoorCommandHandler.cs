using System.Diagnostics.CodeAnalysis;
using HouseIt.Core.Domain;

namespace HouseIt.ConsoleApp.Builders;

[method: SetsRequiredMembers]
public class AddDoorCommandHandler<TRoom>(string key, IUserInterface userInterface, IRoomProvider<TRoom> roomProvider)
    : CommandHandlerBase(key, "Add Door") where TRoom : RoomBase, new()
{
    public override void Handle(DesignRequest designRequest)
    {
        DoorType doorType = userInterface.GetValueFromUser<DoorType>("Enter the door type for door (Single, Double):");
        ColorPalette doorColor = userInterface.GetValueFromUser<ColorPalette>("Enter the door color for door (White, Yellow, Blue, Green):");

        roomProvider.GetRoom(designRequest).Doors.Add(new Door(doorType, doorColor));
    }
}
