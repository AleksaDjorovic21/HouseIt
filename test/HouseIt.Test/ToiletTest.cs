using HouseIt.Core.Domain;

namespace HouseIt.Tests;

public class ToiletTests
{
    [Fact]
    public void ToiletInitialization_SetsToiletProperties()
    {
        //Arrange
        int toiletSize = 100;
        ToiletTypes toiletType = ToiletTypes.Bathtub;
        ColorPalette toiletColor = ColorPalette.Green;
        WindowSizes windowSize = WindowSizes.Medium;
        DoorType doorType = DoorType.Single;
        ColorPalette doorColor = ColorPalette.Green;

        var windows = new List<Window> { new(windowSize), new(windowSize) };
        var doors = new List<Door> { new(doorType, doorColor), new(doorType, doorColor) };

        //Act
        Toilet toilet = new()
        {
            ToiletType = toiletType,
            Sqrm = toiletSize,
            Color = toiletColor,
            Windows = windows,
            Doors = doors,
        };

        //Assert
        Assert.Equal(toiletSize, toilet.Sqrm);
        Assert.Equal(toiletType, toilet.ToiletType);
        Assert.Equal(toiletColor, toilet.Color);
        Assert.Equal(2, toilet.Windows.Count);
        Assert.Equal(2, toilet.Doors.Count);
    }

    [Fact]
    public void ToString_ReturnsFormattedString()
    {
        // Arrange
        int squareMeter = 200;
        ToiletTypes toiletType = ToiletTypes.Shower;
        ColorPalette toiletColor = ColorPalette.Blue;
        var doors = new List<Door> { new(DoorType.Double, ColorPalette.Blue) };
        var windows = new List<Window> { new(WindowSizes.Large), new(WindowSizes.Large), new(WindowSizes.Large) };

        string expectedString = "Toilet: Shower, 200 sqrm, Blue color, 1 Double door (Blue), 3 Large windows";

        // Act
        Toilet toilet = new()
        {
            ToiletType = toiletType,
            Sqrm = squareMeter,
            Color = toiletColor,
            Doors = doors,
            Windows = windows,
        };
        string result = toilet.ToString();

        // Assert
        Assert.Equal(expectedString, result);
    }
}
