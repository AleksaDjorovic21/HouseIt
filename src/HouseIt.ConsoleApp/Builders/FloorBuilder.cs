using System.Diagnostics.CodeAnalysis;
using HouseIt.Core.Domain;

namespace HouseIt.ConsoleApp.Builders;

[method: SetsRequiredMembers]
public class FloorBuilder(IUserInterface userInterface)
    : BuilderBase(userInterface, new AddRoomCommandHandler(userInterface),
                                          new AddKitchenCommandHandler(userInterface),
                                          new AddToiletCommandHandler(userInterface))
{
    [method: SetsRequiredMembers]
    private class AddRoomCommandHandler(IUserInterface userInterface) : CommandHandlerBase("1", "Add Room")
    {
        private readonly IUserInterface UserInterface = userInterface;

        public override void Handle(DesignRequest designRequest)
        {
            UserInterface.WriteLine("Adding a room to the floor.");
            PlainRoomBuilder roomBuilder = new(UserInterface);

            roomBuilder.Build(designRequest);

            UserInterface.WriteLine("Room added to the floor.");
        }
    }

    [method: SetsRequiredMembers]
    private class AddKitchenCommandHandler(IUserInterface userInterface) : CommandHandlerBase("2", "Add Kitchen")
    {
        private readonly IUserInterface UserInterface = userInterface;

        public override void Handle(DesignRequest designRequest)
        {
            UserInterface.WriteLine("Adding a kitchen to the floor.");
            KitchenBuilder kitchenBuilder = new(UserInterface);

            kitchenBuilder.Build(designRequest);

            UserInterface.WriteLine("Kitchen added to the floor.");
        }
    }

    [method: SetsRequiredMembers]
    private class AddToiletCommandHandler(IUserInterface userInterface) : CommandHandlerBase("3", "Add Toilet")
    {
        private readonly IUserInterface UserInterface = userInterface;

        public override void Handle(DesignRequest designRequest)
        {
            UserInterface.WriteLine("Adding a toilet to the floor.");
            ToiletBuilder toiletBuilder = new(UserInterface);

            toiletBuilder.Build(designRequest);

            UserInterface.WriteLine("Toilet added to the floor.");
        }
    }
}
