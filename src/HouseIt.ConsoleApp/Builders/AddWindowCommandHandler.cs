using System.Diagnostics.CodeAnalysis;
using HouseIt.Core.Domain;

namespace HouseIt.ConsoleApp.Builders;

[method: SetsRequiredMembers]
public class AddWindowCommandHandler<TRoom>(string key, IUserInterface userInterface, IRoomProvider<TRoom> roomProvider)
    : CommandHandlerBase(key, "Add Window") where TRoom : RoomBase, new()
{
    public override void Handle(DesignRequest designRequest)
    {
        WindowSizes windowSize = userInterface.GetValueFromUser<WindowSizes>("Enter the size for the window: (Small, Medium, Large):");

        roomProvider.GetRoom(designRequest).Windows.Add(new Window(windowSize));
    }
}
