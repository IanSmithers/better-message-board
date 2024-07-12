using MessageBoard.Data;
using static MessageBoard.Data.Store;

namespace MessageBoard.Core
{
    public class Receiver(ReaderService reader, WriterService writer)
    {
        private readonly bool isDebugEnabled = true;
        private readonly ReaderService reader = reader;
        private readonly WriterService writer = writer;

        public void PostMessage(CommandData inputCommand)
        {
            if (isDebugEnabled) Console.WriteLine($"Called PostMessage/1 with command:{Environment.NewLine}{inputCommand}");

            writer.AddNewMessage(new Message()
            {
                User = inputCommand.UserName,
                Text = inputCommand.MessageText,
                Project = inputCommand.ProjectName,
                TimeStamp = DateTime.Now,
            });
        }

        public void FollowProject(CommandData inputCommand)
        {
            if (isDebugEnabled) Console.WriteLine($"Called FollowProject/1 with command:{Environment.NewLine}{inputCommand}");

            writer.AddUserToProjectFollowing(inputCommand.UserName, inputCommand.ProjectName);
        }

        public void DisplayWall(CommandData inputCommand)
        {
            if (isDebugEnabled) Console.WriteLine($"Called DisplayWall/1 with command:{Environment.NewLine}{inputCommand}");

            var allMessages = reader.GetMessagesForAllProjectsUserIsFollowing(inputCommand.UserName);

            if (allMessages != null)
            {
                foreach (var message in allMessages)
                {
                    Console.WriteLine($"{message.Project} - {message.User}: {message.Text}");
                }
            }
        }

        public void ReadProjectMessages(CommandData inputCommand)
        {
            if (isDebugEnabled) Console.WriteLine($"Called ReadProjectMessages/1 with command:{Environment.NewLine}{inputCommand}");

            var messages = reader.GetMessagesForProject(inputCommand.ProjectName);

            if (messages != null)
            {
                string currentUser = String.Empty; // Important to keep track of the current user to avoid repeating their username.
                foreach (var message in messages)
                {
                    if (message.User != currentUser) Console.WriteLine($"{message.User}{Environment.NewLine}{message.Text}");
                    else
                    {
                        Console.WriteLine(message.Text);
                    }
                    currentUser = message.User;
                }
            }
        }
    }
}
