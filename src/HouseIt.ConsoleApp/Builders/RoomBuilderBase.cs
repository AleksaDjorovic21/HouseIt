using System.Diagnostics.CodeAnalysis;
using HouseIt.Core.Domain;

namespace HouseIt.ConsoleApp.Builders;

[method: SetsRequiredMembers]
public abstract class RoomBuilderBase<TRoom>(
    IUserInterface userInterface,
    params CommandHandlerBase[] handlers) : BuilderBase(userInterface, handlers) where TRoom : RoomBase, new()
{
    public override void Build(DesignRequest designRequest)
    {
        int sqrm = UserInterface.GetValueFromUser<int>("Enter the room size in square meters:");
        ColorPalette roomColor = UserInterface.GetValueFromUser<ColorPalette>("Enter the room color (White, Yellow, Blue, Green).");

        var room = new TRoom
        {
            Sqrm = sqrm,
            Color = roomColor,
        };

        SetRoom(room, designRequest);

        base.Build(designRequest);
    }

    protected abstract void SetRoom(TRoom room, DesignRequest designRequest);
}
