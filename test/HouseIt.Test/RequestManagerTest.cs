using HouseIt.Core.Domain;
using HouseIt.Core.Interfaces;
using Moq;

namespace HouseIt.Tests;

public class RequestManagerTests
{
    [Fact]
    public void SubmitRequest_EmptyRequest_PrintsEmptyRequestMessage()
    {
        // Arrange
        var testDesignRequestDocument = new TestDesignRequestDocument();
        var mockRequestManager = new Mock<IRequestManager>();
        mockRequestManager
            .Setup(rm => rm.SubmitRequestAsync(It.IsAny<DesignRequest>()))
            .Callback<DesignRequest>(request => testDesignRequestDocument.Print(request))
            .Returns(Task.CompletedTask);

        var requestManager = new RequestManager(testDesignRequestDocument, mockRequestManager.Object);
        var designRequest = new DesignRequest("Test Request");

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        requestManager.SubmitRequestAsync(designRequest);

        // Assert
        string output = stringWriter.ToString().Trim();
        Assert.Equal("Request Content: Test Request\r\n*******************", output);

        Console.SetOut(Console.Out);
        stringWriter.Dispose();
    }

    public class TestDesignRequestDocument : IDesignRequestDocument
    {
        public void Print(DesignRequest request)
        {
            Console.WriteLine($"Request Content: {request.Name}");
            Console.WriteLine("*******************");
        }
    }
}

