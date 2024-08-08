using HouseIt.ConsoleApp.Builders;
using HouseIt.ConsoleApp;
using HouseIt.Core.Domain;
using NSubstitute;

namespace HouseIt.Tests;

public class KitchenBuilderTest
{
    [Fact]
    public void Build_Add_Kitchen()
    {
        //Arrange
        var userInterface = Substitute.For<IUserInterface>();
        userInterface.ReadLine().Returns(
            x => "33",
            x => "White",
            x => "true",
            x => "0"
        );

        var designRequest = new DesignRequest("Test");
        var floor = new Floor();
        designRequest.Floors.Add(floor);
        var kitchenBuilder = new KitchenBuilder(userInterface);

        // Act
        kitchenBuilder.Build(designRequest);

        // Assert
        Assert.Single(designRequest.Floors);
        Assert.Single(designRequest.Floors.First().Kitchens);
        var addedKitchen = designRequest.Floors.First().Kitchens.First();

        Assert.True(addedKitchen.HasDiningArea);
        Assert.Equal(33, addedKitchen.Sqrm);
        Assert.Equal(ColorPalette.White, addedKitchen.Color);
    }
}
