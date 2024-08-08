using System.Diagnostics.CodeAnalysis;
using HouseIt.Core.Domain;

namespace HouseIt.ConsoleApp.Builders;

[method: SetsRequiredMembers]
public class PlainRoomBuilder(IUserInterface userInterface)
    : RoomBuilderBase<Room>(userInterface,
        new AddDoorCommandHandler<Room>("1", userInterface, new PlainRoomProvider()),
        new AddWindowCommandHandler<Room>("2", userInterface, new PlainRoomProvider()),
        new BalconyCommandHandler("3", "Add Balcony", userInterface))
{
    protected override void SetRoom(Room room, DesignRequest designRequest)
    {
        RoomTypes roomType = UserInterface.GetValueFromUser<RoomTypes>(
            "Enter the room type (Bedroom, Sitting room, Dining room):");

        room.RoomType = roomType;

        var currentFloor = designRequest.Floors.LastOrDefault(); 
        currentFloor?.AddRoom(room);
    }

    [method: SetsRequiredMembers]
    private class BalconyCommandHandler(string key, string description, IUserInterface userInterface)
        : CommandHandlerBase(key, description)
    {
        readonly IUserInterface _userInterface = userInterface;

        public override void Handle(DesignRequest designRequest)
        {
            var currentFloor = designRequest.Floors.LastOrDefault();
            if (currentFloor != null)
            {
                var currentRoom = currentFloor.Rooms.LastOrDefault();

                if (currentRoom != null)
                {
                    BalconyType balconyType = _userInterface.GetValueFromUser<BalconyType>("Enter the balcony type (Covered, Open):");
                    BalconySize balconySize = _userInterface.GetValueFromUser<BalconySize>("Enter the balcony size (Small, Medium, Large):");

                    currentRoom.Balcony = new Balcony(balconySize, balconyType);
                }
            }
        }
    }
}
