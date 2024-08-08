using HouseIt.Core.Domain;

namespace HouseIt.Tests;

public class OrdinalUtilityTests
{
    [Theory]
    [InlineData(1, "1st")]
    [InlineData(2, "2nd")]
    [InlineData(3, "3rd")]
    [InlineData(4, "4th")]
    [InlineData(10, "10th")]
    [InlineData(11, "11th")]
    [InlineData(12, "12th")]
    [InlineData(13, "13th")]
    [InlineData(20, "20th")]
    [InlineData(21, "21st")]
    [InlineData(22, "22nd")]
    [InlineData(23, "23rd")]
    [InlineData(24, "24th")]
    public void ConvertToOrdinal_ShouldReturnExpectedResult(int number, string expectedOrdinal)
    {
        // Act
        string result = OrdinalUtility.ConvertToOrdinal(number);

        // Assert
        Assert.Equal(expectedOrdinal, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ConvertToOrdinal_ShouldReturnNumberForInvalidCases(int number)
    {
        // Act
        string result = OrdinalUtility.ConvertToOrdinal(number);

        // Assert
        Assert.Equal(number.ToString(), result);
    }
}

