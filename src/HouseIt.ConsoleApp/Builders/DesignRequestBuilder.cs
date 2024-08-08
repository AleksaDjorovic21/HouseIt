using System.Diagnostics.CodeAnalysis;
using HouseIt.Core.Domain;

namespace HouseIt.ConsoleApp.Builders;

[method: SetsRequiredMembers]
public class DesignRequestBuilder(IUserInterface userInterface)
    : BuilderBase(userInterface, new AddFloorCommandHandler(userInterface))
{
    [method: SetsRequiredMembers]
    private class AddFloorCommandHandler(IUserInterface userInterface) : CommandHandlerBase("1", "Add Floor")
    {
        private readonly IUserInterface UserInterface = userInterface;
        public override void Handle(DesignRequest designRequest)
        {
            designRequest.Floors.Add(new Floor());
            FloorBuilder floorBuilder = new(UserInterface);
            floorBuilder.Build(designRequest);
        }
    }
}
