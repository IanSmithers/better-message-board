
using static MessageBoard.Data.Store;

namespace MessageBoard.Data
{
    public class WriterService(Store store) : ServiceBase(store)
    {
        public void AddNewMessage(Message message)
        {
            store.AddNewMessage(message);
        }

        public void AddUserToProjectFollowing(string userName, string projectName)
        {
            store.AddUserToProjectFollowing(userName, projectName);
        }
    }
}
