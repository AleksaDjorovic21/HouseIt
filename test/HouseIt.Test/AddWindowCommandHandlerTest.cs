using HouseIt.ConsoleApp.Builders;
using HouseIt.ConsoleApp;
using HouseIt.Core.Domain;
using NSubstitute;

namespace HouseIt.Tests;

public class AddWindowCommandHandlerTest
{
    [Fact]
    public void Handle_Adds_Window()
    {
        // Arrange
        var userInterface = Substitute.For<IUserInterface>();
        userInterface.ReadLine().Returns(
        x => "Medium",
        x => "0"
    );

        var designRequest = new DesignRequest("Test");
        var floor = new Floor();
        var room = new Room
        {
            Sqrm = 100,
            Color = ColorPalette.White,
            RoomType = RoomTypes.Bedroom
        };

        floor.AddRoom(room);
        designRequest.Floors.Add(floor);

        var commandHandler = new AddWindowCommandHandler<Room>("1", userInterface, new PlainRoomProvider());

        // Act
        commandHandler.Handle(designRequest);

        // Assert
        Assert.Single(room.Windows);
        var addedWindow = room.Windows.First();

        Assert.Equal(WindowSizes.Medium, addedWindow.Size);
    }

    [Fact]
    public void Handle_Does_Not_Add_Window_On_Invalid_Size()
    {
        // Arrange
        var userInterface = Substitute.For<IUserInterface>();
        userInterface.ReadLine().Returns(
            x => "InvalidSize",
            x => "Medium",
            x => "0"
        );

        var designRequest = new DesignRequest("Test");
        var floor = new Floor();
        var room = new Room
        {
            Sqrm = 100,
            Color = ColorPalette.White,
            RoomType = RoomTypes.Bedroom
        };

        floor.AddRoom(room);
        designRequest.Floors.Add(floor);

        var commandHandler = new AddWindowCommandHandler<Room>("1", userInterface, new PlainRoomProvider());

        // Act
        commandHandler.Handle(designRequest);

        // Assert
        Assert.Single(room.Windows);
        var addedWindow = room.Windows.First();

        Assert.Equal(WindowSizes.Medium, addedWindow.Size);
    }
}

