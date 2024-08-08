namespace HouseIt.ConsoleApp;

public class UserConsoleInterface : IUserInterface
{
    public string? ReadLine()
    {
        return Console.ReadLine();
    }

    public void WriteLine()
    {
        Console.WriteLine();
    }

    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}
