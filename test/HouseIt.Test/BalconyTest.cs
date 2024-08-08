using HouseIt.Core.Domain;

namespace HouseIt.Tests;
public class BalconyTests
{
    [Fact]
    public void BalconyToString_ReturnsFormattedString()
    {
        // Arrange
        BalconySize size = BalconySize.Medium;
        BalconyType type = BalconyType.Covered;
        Balcony balcony = new(size, type);
        string expectedString = $"Balcony: {size} {type}";

        // Act
        string result = balcony.ToString();

        // Assert
        Assert.True(string.Equals(expectedString.Trim(), result.Trim(), StringComparison.OrdinalIgnoreCase));
    }
}

