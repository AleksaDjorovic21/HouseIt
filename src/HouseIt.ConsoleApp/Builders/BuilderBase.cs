using System.Diagnostics.CodeAnalysis;
using HouseIt.Core.Domain;

namespace HouseIt.ConsoleApp.Builders;

[method: SetsRequiredMembers]
public abstract class BuilderBase(
    IUserInterface userInterface,
    params CommandHandlerBase[] handlers)
{

    protected readonly IUserInterface UserInterface = userInterface;
    private readonly CommandHandlerBase[] _handlers =
      [.. handlers.Append(new DoneCommandHandler())];

    public virtual void Build(DesignRequest designRequest)
    {
        while (true)
        {
            PrintCommands();

            string? command = UserInterface.ReadLine();

            CommandHandlerBase? handler = _handlers
                .FirstOrDefault(x => x.Key == command!);

            if (handler == null)
            {
                UserInterface.WriteLine("Enter the valid command.");
                continue;
            }

            if (handler is DoneCommandHandler)
            {
                break;
            }

            handler.Handle(designRequest);

            continue;
        }
    }

    private void PrintCommands()
    {
        UserInterface.WriteLine(".....................");
        UserInterface.WriteLine("Enter the command number.");
        foreach (var handler in _handlers)
        {
            UserInterface.WriteLine($"{handler.Key}. {handler.Description}");
        }
        UserInterface.WriteLine(".....................");
    }

    [method: SetsRequiredMembers]
    private class DoneCommandHandler() : CommandHandlerBase("0", "Done")
    {
        public override void Handle(DesignRequest designRequest)
        {
            return;
        }
    }
}
