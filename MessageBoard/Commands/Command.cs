using MessageBoard.Core;

namespace MessageBoard.Commands
{
    /// <summary>
    /// Used to handle unique command functionality.
    /// All commands will eventually execute a receiver method.
    /// However each command can include it's own functionality if required.
    /// Ex: push notification, send an event, play a sound effect, update data.
    /// </summary>
    /// <param name="receiver"></param>
    public abstract class Command(Receiver receiver)
    {
        private protected Receiver receiver = receiver;

        public abstract void Execute(CommandData inputCommand);
    }
}
