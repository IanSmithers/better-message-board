
namespace MessageBoard.Data
{
    public class Store
    {
        public struct Message
        {
            public string User { get; set; }
            public string Text { get; set; }
            public DateTime TimeStamp { get; set; }
            public string Project { get; set; }
        }

        private readonly Dictionary<string, List<string>> userFollowing = [];
        private readonly Dictionary<string, List<Message>> projectMessages = [];

        internal List<Message>? GetProjectMessages(string projectName)
        {
            projectMessages.TryGetValue(projectName, out var list);
            return list;
        }

        internal IOrderedEnumerable<Message>? GetMessagesForAllProjectsUserIsFollowing(string userName)
        {
            if (userFollowing.TryGetValue(userName, out var projects))
            {
                var allMessages = new List<Message>();
                foreach (var projectName in projects)
                {
                    if (projectMessages.TryGetValue(projectName, out var messages))
                    {
                        allMessages.AddRange(messages);
                    }
                }

                return allMessages.OrderBy(msg => msg.TimeStamp);
            }

            return null;
        }

        internal void AddNewMessage(Message message)
        {
            if (!projectMessages.TryGetValue(message.Project, out _))
            {
                List<Message>? messages = [];
                projectMessages.Add(message.Project, messages);
            }

            projectMessages[message.Project].Add(message);
        }

        internal void AddUserToProjectFollowing(string userName, string projectName)
        {
            if (!userFollowing.TryGetValue(userName, out List<string>? projects))
            {
                projects = [];
                userFollowing.Add(userName, projects);
            }

            projects.Add(projectName);
        }
    }
}