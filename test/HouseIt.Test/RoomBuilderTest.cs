using HouseIt.ConsoleApp.Builders;
using HouseIt.ConsoleApp;
using HouseIt.Core.Domain;
using NSubstitute;

namespace HouseIt.Tests;

public class RoomBuilderTests
{
    [Fact]
    public void Build_Adds_Room_To_DesignRequest()
    {
        // Arrange
        var userInterface = Substitute.For<IUserInterface>();
        userInterface.ReadLine().Returns(
            x => "33",
            x => "White",
            x => "Bedroom",
            x => "1",
            x => "Single",
            x => "White",
            x => "2",
            x => "Small",
            x => "3",
            x => "Open",
            x => "Small",
            x => "0"
        );

        var designRequest = new DesignRequest("Test");
        var floor = new Floor();
        designRequest.Floors.Add(floor);
        var roomBuilder = new PlainRoomBuilder(userInterface);

        // Act
        roomBuilder.Build(designRequest);

        // Assert for Rooms
        Assert.Single(designRequest.Floors);
        var lastFloor = designRequest.Floors.ElementAt(designRequest.Floors.Count - 1);

        Assert.Single(lastFloor.Rooms);
        var addedRoom = lastFloor.Rooms.ElementAt(lastFloor.Rooms.Count - 1);

        Assert.Equal(RoomTypes.Bedroom, addedRoom.RoomType);
        Assert.Equal(33, addedRoom.Sqrm);
        Assert.Equal(ColorPalette.White, addedRoom.Color);

        // Assert for Door
        Assert.Single(addedRoom.Doors);
        var addedDoor = addedRoom.Doors.ElementAt(addedRoom.Doors.Count - 1);
        Assert.Equal(DoorType.Single, addedDoor.Type);
        Assert.Equal(ColorPalette.White, addedDoor.Color);

        // Assert for Window
        Assert.Single(addedRoom.Windows);
        var addedWindow = addedRoom.Windows.ElementAt(addedRoom.Windows.Count - 1);
        Assert.Equal(WindowSizes.Small, addedWindow.Size);

        // Assert for Balcony
        Assert.NotNull(addedRoom.Balcony);
        Assert.Equal(BalconyType.Open, addedRoom.Balcony.Type);
        Assert.Equal(BalconySize.Small, addedRoom.Balcony.Size);
    }
}
