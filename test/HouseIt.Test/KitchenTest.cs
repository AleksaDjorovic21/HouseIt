using HouseIt.Core.Domain;

namespace HouseIt.Tests;

public class KitchenTests
{
    [Fact]
    public void KitchenInitialization_SetsKitchenProperties()
    {
        // Arrange
        int kitchenSize = 100;
        ColorPalette kitchenColor = ColorPalette.Green;
        WindowSizes windowSize = WindowSizes.Medium;
        DoorType doorType = DoorType.Single;
        ColorPalette doorColor = ColorPalette.Green;

        var windows = new List<Window> { new(windowSize), new(windowSize) };
        var doors = new List<Door> { new(doorType, doorColor), new(doorType, doorColor) };

        // Act
        Kitchen kitchen = new()
        {
            Sqrm = kitchenSize,
            Color = kitchenColor,
            Windows = windows,
            Doors = doors,
            HasDiningArea = true
        };

        // Assert
        Assert.Equal(kitchenSize, kitchen.Sqrm);
        Assert.Equal(kitchenColor, kitchen.Color);
        Assert.Equal(2, kitchen.Windows.Count);
        Assert.Equal(2, kitchen.Doors.Count);
        Assert.True(kitchen.HasDiningArea);
    }

    [Fact]
    public void ToString_ReturnsFormattedString()
    {
        // Arrange
        int kitchenSize = 150;
        ColorPalette kitchenColor = ColorPalette.Yellow;
        var windows = new List<Window> { new(WindowSizes.Small), new(WindowSizes.Large) };
        var doors = new List<Door> { new(DoorType.Double, ColorPalette.Blue) };

        string expectedString = "Kitchen: 150 sqrm, Yellow color, 1 Double door (Blue), 1 Small window, 1 Large window, With dining area";

        // Act
        Kitchen kitchen = new()
        {
            Sqrm = kitchenSize,
            Color = kitchenColor,
            Windows = windows,
            Doors = doors,
            HasDiningArea = true
        };

        string result = kitchen.ToString();

        // Assert
        Assert.Equal(expectedString, result);
    }
}

