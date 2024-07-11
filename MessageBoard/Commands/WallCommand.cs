using MessageBoard.Core;

namespace MessageBoard.Commands
{
    internal class WallCommand(Receiver receiver) : Command(receiver)
    {
        public override void Execute(InputCommand inputCommand)
        {
            receiver.DisplayWall(inputCommand);
        }
    }
}
