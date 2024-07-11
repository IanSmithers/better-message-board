
using MessageBoard.Commands;

namespace MessageBoard.Core
{
    internal class Invoker
    {
        private Command? command;

        public void SetCommand(Command command)
        {
            this.command = command;
        }

        public void ExecuteCommand(InputCommand inputCommand)
        {
            command?.Execute(inputCommand);
        }
    }
}
