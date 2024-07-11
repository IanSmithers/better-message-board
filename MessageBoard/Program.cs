// See https://aka.ms/new-console-template for more information

using MessageBoard.Commands;
using MessageBoard.Core;

Invoker invoker = new();
Receiver receiver = new();

Command followCommand = new FollowCommand(receiver);
Command postCommand = new PostCommand(receiver);
Command readCommand = new ReadCommand(receiver);
Command wallCommand = new WallCommand(receiver);

while (true)
{
    var input = Console.ReadLine();

    // TODO Wired up basic commands just to get the flow working. This will be replaced with something more robust.
    // I was thinking to create a inputcommand class, that is furnished with data from the input command and then
    // could be easily switched over. Ex: InputCommand.Follow -> would trigger followCommand path.

    if (input != null)
    {
        var inputCommand = Parser.ParseInputCommand(input); // Not currently implemented.

        switch (input)
        {
            case "Follow":
                invoker.SetCommand(followCommand);
                break;
            case "Wall":
                invoker.SetCommand(wallCommand);
                break;
            case "Post":
                invoker.SetCommand(postCommand);
                break;
            case "Read":
                invoker.SetCommand(readCommand);
                break;
            default:
                break;
        }

        invoker.ExecuteCommand(inputCommand);
    }
}
