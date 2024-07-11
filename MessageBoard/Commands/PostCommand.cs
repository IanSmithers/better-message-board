using MessageBoard.Core;

namespace MessageBoard.Commands
{
    internal class PostCommand(Receiver receiver) : Command(receiver)
    {
        public override void Execute(CommandData inputCommand)
        {
            receiver.PostMessage(inputCommand);
        }
    }
}
