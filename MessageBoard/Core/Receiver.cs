
namespace MessageBoard.Core
{
    struct Message
    {
        public string User {  get; set; }
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class Receiver
    {
        private readonly bool isDebugEnabled = false;
        private readonly Dictionary<string, List<string>> userFollowing = [];
        private readonly Dictionary<string, List<Message>> projectMessages = [];

        public void PostMessage(InputCommand inputCommand)
        {
            if (isDebugEnabled) Console.WriteLine($"Called PostMessage/1 with command:{Environment.NewLine}{inputCommand}");

            if (!projectMessages.TryGetValue(inputCommand.ProjectName, out List<Message>? messages))
            {
                messages = [];
                projectMessages.Add(inputCommand.ProjectName, messages);
            }

            messages.Add(new Message()
            {
                User = inputCommand.UserName,
                Text = inputCommand.MessageText,
                TimeStamp = DateTime.Now,
            });
        }

        public void FollowProject(InputCommand inputCommand)
        {
            if (isDebugEnabled) Console.WriteLine($"Called FollowProject/1 with command:{Environment.NewLine}{inputCommand}");

            if (!userFollowing.TryGetValue(inputCommand.UserName, out List<string>? projects))
            {
                projects = [];
                userFollowing.Add(inputCommand.UserName, projects);
            }

            projects.Add(inputCommand.ProjectName);
        }

        public void DisplayWall(InputCommand inputCommand)
        {
            if (isDebugEnabled) Console.WriteLine($"Called DisplayWall/1 with command:{Environment.NewLine}{inputCommand}");

            if (userFollowing.TryGetValue(inputCommand.UserName, out var projects))
            {
                var allMessages = new List<Message>();
                foreach (var projectName in projects)
                {
                    if (projectMessages.TryGetValue(projectName, out var messages))
                    {
                        allMessages.AddRange(messages);
                    }
                }

                foreach (var message in allMessages.OrderBy(msg => msg.TimeStamp))
                {
                    Console.WriteLine(message.Text);
                }
            }
        }

        public void ReadProjectMessages(InputCommand inputCommand)
        {
            if (isDebugEnabled) Console.WriteLine($"Called ReadProjectMessages/1 with command:{Environment.NewLine}{inputCommand}");

            if (projectMessages.TryGetValue(inputCommand.ProjectName, out var messages))
            {
                foreach (var message in messages)
                {
                    Console.WriteLine(message.Text);
                }
            }
        }
    }
}
