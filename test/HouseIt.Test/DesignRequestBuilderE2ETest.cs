using HouseIt.ConsoleApp.Builders;
using HouseIt.ConsoleApp;
using HouseIt.Core.Domain;
using NSubstitute;

namespace HouseIt.Tests;

public class DesignRequestBuilderE2ETest
{
    [Fact]
    public void Build_DesignRequest_With_Rooms_Kitchen_And_Toilets()
    {
        // Arrange
        var userInterface = Substitute.For<IUserInterface>();
        userInterface.ReadLine().Returns(
            x => "1",
            x => "1",
            x => "33",
            x => "White",
            x => "Bedroom",
            x => "1",
            x => "Single",
            x => "White",
            x => "0",
            x => "2",
            x => "25",
            x => "White",
            x => "true",
            x => "0",
            x => "3",
            x => "20",
            x => "Blue",
            x => "Shower",
            x => "0",
            x => "0",
            x => "0"
        );

        var designRequestBuilder = new DesignRequestBuilder(userInterface);
        var designRequest = new DesignRequest("Test Request");

        // Act
        designRequestBuilder.Build(designRequest);

        // Assert
        Assert.Equal("Test Request", designRequest.Name);
        Assert.Single(designRequest.Floors);

        var floor = designRequest.Floors.ElementAt(designRequest.Floors.Count - 1);
        Assert.Single(floor.Rooms);
        Assert.Single(floor.Kitchens);
        Assert.Single(floor.Toilets);

        var room = floor.Rooms.ElementAt(floor.Rooms.Count - 1);
        Assert.Equal(33, room.Sqrm);
        Assert.Equal(ColorPalette.White, room.Color);
        Assert.Equal(RoomTypes.Bedroom, room.RoomType);

        var kitchen = floor.Kitchens.ElementAt(floor.Kitchens.Count - 1);
        Assert.Equal(25, kitchen.Sqrm);
        Assert.Equal(ColorPalette.White, kitchen.Color);
        Assert.True(kitchen.HasDiningArea);

        var toilet = floor.Toilets.ElementAt(floor.Toilets.Count - 1);
        Assert.Equal(20, toilet.Sqrm);
        Assert.Equal(ColorPalette.Blue, toilet.Color);
        Assert.Equal(ToiletTypes.Shower, toilet.ToiletType);
    }

    [Fact]
    public void Build_DesignRequest_With_Failure()
    {
        // Arrange
        var userInterface = Substitute.For<IUserInterface>();
        userInterface.ReadLine().Returns(
            x => "1",
            x => "1",
            x => "InvalidSqrm",
            x => "33",
            x => "White",
            x => "Bedroom",
            x => "1",
            x => "Single",
            x => "White",
            x => "0",
            x => "2",
            x => "25",
            x => "White",
            x => "true",
            x => "0",
            x => "3",
            x => "20",
            x => "Blue",
            x => "Shower",
            x => "0",
            x => "0",
            x => "0"
        );

        var designRequestBuilder = new DesignRequestBuilder(userInterface);
        var designRequest = new DesignRequest("Test Request");

        // Act
        designRequestBuilder.Build(designRequest);

        // Assert
        Assert.Equal("Test Request", designRequest.Name);
        Assert.Single(designRequest.Floors);

        var floor = designRequest.Floors.ElementAt(designRequest.Floors.Count - 1);
        Assert.Single(floor.Rooms);
        Assert.Single(floor.Kitchens);
        Assert.Single(floor.Toilets);

        var room = floor.Rooms.ElementAt(floor.Rooms.Count - 1);
        Assert.Equal(33, room.Sqrm);
        Assert.Equal(ColorPalette.White, room.Color);
        Assert.Equal(RoomTypes.Bedroom, room.RoomType);

        var kitchen = floor.Kitchens.ElementAt(floor.Kitchens.Count - 1);
        Assert.Equal(25, kitchen.Sqrm);
        Assert.Equal(ColorPalette.White, kitchen.Color);
        Assert.True(kitchen.HasDiningArea);

        var toilet = floor.Toilets.ElementAt(floor.Toilets.Count - 1);
        Assert.Equal(20, toilet.Sqrm);
        Assert.Equal(ColorPalette.Blue, toilet.Color);
        Assert.Equal(ToiletTypes.Shower, toilet.ToiletType);
    }
}

