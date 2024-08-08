using HouseIt.ConsoleApp.Builders;
using HouseIt.ConsoleApp;
using HouseIt.Core.Domain;
using NSubstitute;

namespace HouseIt.Tests;

public class ToiletBuilderTest
{
    [Fact]
    public void Build_Add_Toilet()
    {
        //Arrange
        var userInterface = Substitute.For<IUserInterface>();
        userInterface.ReadLine().Returns(
            x => "33",
            x => "White",
            x => "Shower",
            x => "0"
        );

        var designRequest = new DesignRequest("Test");
        var floor = new Floor();
        designRequest.Floors.Add(floor);
        var toiletBuilder = new ToiletBuilder(userInterface);

        // Act
        toiletBuilder.Build(designRequest);

        // Assert
        Assert.Single(designRequest.Floors);
        var lastFloor = designRequest.Floors.ElementAt(designRequest.Floors.Count - 1);

        Assert.Single(lastFloor.Toilets);
        var addedToilet = lastFloor.Toilets.ElementAt(lastFloor.Toilets.Count - 1);

        Assert.Equal(ToiletTypes.Shower, addedToilet.ToiletType);
        Assert.Equal(33, addedToilet.Sqrm);
        Assert.Equal(ColorPalette.White, addedToilet.Color);
    }

    [Fact]
    public void Build_Invalid_SquareMeter()
    {
        // Arrange
        var userInterface = Substitute.For<IUserInterface>();
        userInterface.ReadLine().Returns(
            x => "InvalidSquareMeter",
            x => "33",
            x => "White",
            x => "Shower",
            x => "0"
        );

        var designRequest = new DesignRequest("Test");
        var floor = new Floor();
        designRequest.Floors.Add(floor);
        var toiletBuilder = new ToiletBuilder(userInterface);

        // Act
        toiletBuilder.Build(designRequest);

        // Assert
        Assert.Single(designRequest.Floors);
        var lastFloor = designRequest.Floors.ElementAt(designRequest.Floors.Count - 1);
        
        Assert.Single(lastFloor.Toilets);
        var addedToilet = lastFloor.Toilets.ElementAt(lastFloor.Toilets.Count - 1);

        Assert.Equal(ToiletTypes.Shower, addedToilet.ToiletType);
        Assert.Equal(33, addedToilet.Sqrm);
        Assert.Equal(ColorPalette.White, addedToilet.Color);
    }
}
