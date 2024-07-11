using MessageBoard.Core;

namespace MessageBoard.Commands
{
    internal class FollowCommand(Receiver receiver) : Command(receiver)
    {
        public override void Execute(InputCommand inputCommand)
        {
            receiver.FollowProject(inputCommand);
        }
    }
}
