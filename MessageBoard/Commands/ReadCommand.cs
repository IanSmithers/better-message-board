using MessageBoard.Core;

namespace MessageBoard.Commands
{
    internal class ReadCommand(Receiver receiver) : Command(receiver)
    {
        public override void Execute(InputCommand inputCommand)
        {
            receiver.ReadProjectMessages(inputCommand);
        }
    }
}
