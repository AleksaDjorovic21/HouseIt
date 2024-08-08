using System.Text;
using HouseIt.Core.Domain;

namespace HouseIt.ConsoleApp;

public class DesignRequestConsoleDocument(IUserInterface userInterface) : IDesignRequestDocument
{
    private readonly IUserInterface _userInterface = userInterface;
    public void Print(DesignRequest request)
    {
        StringBuilder stringBuilder = new();

        stringBuilder.AppendLine();
        stringBuilder.Append("************************");
        stringBuilder.AppendLine();
        stringBuilder.Append("Design Request");
        stringBuilder.AppendLine();
        stringBuilder.Append("************************");
        stringBuilder.AppendLine();
        stringBuilder.Append(request.ToString());
        stringBuilder.Append("************************");

        _userInterface.WriteLine(stringBuilder.ToString());
    }
}


