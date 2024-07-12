using static MessageBoard.Data.Store;

namespace MessageBoard.Data
{
    public class ReaderService(Store store) : ServiceBase(store)
    {
        internal List<Message>? GetMessagesForProject(string projectName)
        {
            return store.GetProjectMessages(projectName);
        }

        internal IOrderedEnumerable<Message>? GetMessagesForAllProjectsUserIsFollowing(string userName)
        {
            return store.GetMessagesForAllProjectsUserIsFollowing(userName);
        }
    }
}
