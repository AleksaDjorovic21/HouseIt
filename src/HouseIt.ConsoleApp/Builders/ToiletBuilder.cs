using System.Diagnostics.CodeAnalysis;
using HouseIt.Core.Domain;

namespace HouseIt.ConsoleApp.Builders;

[method: SetsRequiredMembers]
public class ToiletBuilder(IUserInterface userInterface)
    : RoomBuilderBase<Toilet>(userInterface,
        new AddDoorCommandHandler<Toilet>("1", userInterface, new ToiletRoomProvider()),
        new AddWindowCommandHandler<Toilet>("2", userInterface, new ToiletRoomProvider()))
{
    protected override void SetRoom(Toilet room, DesignRequest designRequest)
    {
        ToiletTypes toiletType = UserInterface.GetValueFromUser<ToiletTypes>(
            "Enter the toilet type (Bathtub, Shower):");

        room.ToiletType = toiletType;

        var lastFloor = designRequest.Floors.LastOrDefault() 
            ?? throw new InvalidOperationException("No floors found in the design request."); 

        lastFloor.AddToilet(room);
    }
}
