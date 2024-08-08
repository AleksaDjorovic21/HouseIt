using HouseIt.ConsoleApp.Builders;
using HouseIt.ConsoleApp;
using HouseIt.Core.Domain;
using NSubstitute;

namespace HouseIt.Tests;

public class AddDoorCommandHandlerTest
{
    [Fact]
    public void Handler_Adds_Door()
    {
        // Arrange
        var userInterface = Substitute.For<IUserInterface>();
        userInterface.ReadLine().Returns(
            x => "Single",
            x => "White",
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

        var commandHandler = new AddDoorCommandHandler<Room>("1", userInterface, new PlainRoomProvider());

        // Act
        commandHandler.Handle(designRequest);

        // Assert
        Assert.Single(room.Doors);
        var addedDoor = room.Doors.ElementAt(room.Doors.Count - 1);

        Assert.Equal(DoorType.Single, addedDoor.Type);
        Assert.Equal(ColorPalette.White, addedDoor.Color);
    }

    [Fact]
    public void Handler_Retries_On_Invalid_Type()
    {
        // Arrange
        var userInterface = Substitute.For<IUserInterface>();
        userInterface.ReadLine().Returns(
            x => "InvalidType",
            x => "Single",
            x => "White",
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

        var commandHandler = new AddDoorCommandHandler<Room>("1", userInterface, new PlainRoomProvider());

        // Act
        commandHandler.Handle(designRequest);

        // Assert
        Assert.Single(room.Doors);
        var addedDoor = room.Doors.ElementAt(room.Doors.Count - 1);
        Assert.Equal(DoorType.Single, addedDoor.Type);
        Assert.Equal(ColorPalette.White, addedDoor.Color);
    }

    [Fact]
    public void Handler_Retries_On_Invalid_Color()
    {
        // Arrange
        var userInterface = Substitute.For<IUserInterface>();
        userInterface.ReadLine().Returns(
            x => "Single",
            x => "InvalidColor",
            x => "White",
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

        var commandHandler = new AddDoorCommandHandler<Room>("1", userInterface, new PlainRoomProvider());

        // Act
        commandHandler.Handle(designRequest);

        // Assert
        Assert.Single(room.Doors);
        var addedDoor = room.Doors.ElementAt(room.Doors.Count - 1);
        Assert.Equal(DoorType.Single, addedDoor.Type);
        Assert.Equal(ColorPalette.White, addedDoor.Color);
    }
}

