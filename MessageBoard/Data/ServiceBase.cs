namespace MessageBoard.Data
{
    public class ServiceBase(Store store)
    {
        protected readonly Store store = store;
    }
}