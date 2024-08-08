using System.Diagnostics.CodeAnalysis;
using HouseIt.Core.Domain;

namespace HouseIt.ConsoleApp.Builders;

[method: SetsRequiredMembers]
public class KitchenBuilder(IUserInterface userInterface)
    : RoomBuilderBase<Kitchen>(userInterface,
        new AddDoorCommandHandler<Kitchen>("1", userInterface, new KitchenRoomProvider()),
        new AddWindowCommandHandler<Kitchen>("2", userInterface, new KitchenRoomProvider()))
{
    protected override void SetRoom(Kitchen room, DesignRequest designRequest)
    {
        bool hasDiningArea = UserInterface.GetValueFromUser<bool>("Does the kitchen have a dining area? (true/false):");
        room.HasDiningArea = hasDiningArea;

        var lastFloor = designRequest.Floors.LastOrDefault() 
            ?? throw new InvalidOperationException("No floors found in the design request.");
            
        lastFloor.AddKitchen(room);
    }
}

