
namespace MessageBoard.Core
{
    // TODO Create collections to store the users/messages/posts and follow flags.
    

    public class Receiver
    {
        public void PostMessage(InputCommand inputCommand) => Console.WriteLine($"Called PostMessage/1 with command:{Environment.NewLine}{inputCommand}");

        public void FollowProject(InputCommand inputCommand) => Console.WriteLine($"Called FollowProject/1 with command:{Environment.NewLine}{inputCommand}");

        public void DisplayWall(InputCommand inputCommand) => Console.WriteLine($"Called DisplayWall/1 with command:{Environment.NewLine}{inputCommand}");

        public void ReadProjectMessages(InputCommand inputCommand) => Console.WriteLine($"Called ReadProjectMessages/1 with command:{Environment.NewLine}{inputCommand}");
    }
}
