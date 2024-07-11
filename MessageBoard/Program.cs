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

    if (input != null)
    {
        var inputCommand = Parser.ParseInputCommand(input);

        // Test *all* criteria for a post message command.
        if (
            inputCommand.MessageText != String.Empty &&
            inputCommand.UserName != String.Empty &&
            inputCommand.TimeStamp != null
            )
        {
            invoker.SetCommand(postCommand);
        }

        else if(inputCommand.DisplayWall) invoker.SetCommand(wallCommand);

        else if (inputCommand.Following) invoker.SetCommand(followCommand);

        // Will execute for any single word entry into the console which is desired.
        // The word will either be a recorded valid project name or will not be found.
        else if (inputCommand.ProjectName != String.Empty) invoker.SetCommand(readCommand);

        invoker.ExecuteCommand(inputCommand);
    }
}
