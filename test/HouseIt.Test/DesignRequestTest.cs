using HouseIt.Core.Domain;

namespace HouseIt.Tests;

public class DesignRequestTests
{
    [Fact]
    public void EmptyDesignRequest_IsEmptyReturnsTrue()
    {
        // Arrange
        string requestName = "Empty Test Request";
        var designRequest = new DesignRequest(requestName);

        // Act & Assert
        Assert.True(designRequest.IsEmpty());
    }

    [Fact]
    public void NonEmptyDesignRequest_IsEmptyReturnsFalse()
    {
        // Arrange
        string requestName = "Non-Empty Test Request";
        var designRequest = new DesignRequest(requestName);
        designRequest.Floors.Add(new Floor());

        // Act & Assert
        Assert.False(designRequest.IsEmpty());
    }

    [Fact]
    public void DesignRequest_ToStringReturnsCorrectFormat()
    {
        // Arrange
        string requestName = "Test Request";
        var designRequest = new DesignRequest(requestName);
        designRequest.Floors.Add(new Floor());

        // Act
        string result = designRequest.ToString();

        // Assert
        Assert.Contains($"Request name: {requestName}", result);
        Assert.Contains("Number of Floors: 1", result);
        Assert.Contains("1st Floor", result);
    }
}

