using HouseIt.Core.Domain;

namespace HouseIt.Tests;

public class RoomTests
{
    [Fact]
    public void RoomInitialization_SetsSquareMeter()
    {
        // Arrange
        int squareMeter = 150;
        RoomTypes roomType = RoomTypes.Bedroom;
        ColorPalette roomColor = ColorPalette.White;
        ColorPalette doorColor = ColorPalette.White;
        WindowSizes windowSize = WindowSizes.Small;

        var doors = new List<Door> { new(DoorType.Single, doorColor) };
        var windows = new List<Window> { new(windowSize), new(windowSize) };
        Balcony balcony = new(BalconySize.Medium, BalconyType.Covered);

        // Act
        Room room = new()
        {
            RoomType = roomType,
            Sqrm = squareMeter,
            Color = roomColor,
            Doors = doors,
            Windows = windows,
            Balcony = balcony
        };

        // Assert
        Assert.Equal(squareMeter, room.Sqrm);
        Assert.Equal(roomType, room.RoomType);
        Assert.Equal(roomColor, room.Color);
        Assert.Single(room.Doors);
        Assert.Equal(2, room.Windows.Count);
        Assert.True(room.HasBalcony);
        Assert.NotNull(room.Balcony);
        Assert.Equal(BalconySize.Medium, room.Balcony.Size);
        Assert.Equal(BalconyType.Covered, room.Balcony.Type);
    }

    [Fact]
    public void ToString_ReturnsFormattedString()
    {
        // Arrange
        int squareMeter = 200;
        RoomTypes roomType = RoomTypes.SittingRoom;
        ColorPalette roomColor = ColorPalette.Blue;
        var doors = new List<Door> { new(DoorType.Double, ColorPalette.Blue) };
        var windows = new List<Window> { new(WindowSizes.Large), new(WindowSizes.Large), new(WindowSizes.Large) };

        string expectedString = "SittingRoom: 200 sqrm, Blue color, 1 Double door (Blue), 3 Large windows, No balcony";

        // Act
        Room room = new()
        {
            RoomType = roomType,
            Sqrm = squareMeter,
            Color = roomColor,
            Doors = doors,
            Windows = windows,
            Balcony = null
        };
        string result = room.ToString();

        // Assert
        Assert.Equal(expectedString, result);
    }
}


