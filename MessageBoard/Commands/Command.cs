using MessageBoard.Core;

namespace MessageBoard.Commands
{
    public abstract class Command(Receiver receiver)
    {
        private protected Receiver receiver = receiver;

        public abstract void Execute(InputCommand inputCommand);
    }
}
