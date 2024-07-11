namespace MessageBoard.Core
{
    public class CommandData
    {
        public string UserName { get; set; } = String.Empty;
        public string MessageText { get; set; } = String.Empty;
        public DateTime? TimeStamp { get; set; } = null;
        public string ProjectName { get; set; } = String.Empty;
        public bool Following { get; set; }
        public bool DisplayWall { get; set; }

        public override string ToString()
        {
            return @$"UserName: {UserName}" + Environment.NewLine +
                    $"MessageText: {MessageText}" + Environment.NewLine +
                    $"TimeStamp: {TimeStamp}" + Environment.NewLine +
                    $"ProjectName: {ProjectName}" + Environment.NewLine +
                    $"Following: {Following}" + Environment.NewLine +
                    $"DisplayWall: {DisplayWall}" + Environment.NewLine;
        }
    }

    internal static class Parser
    {
        public static CommandData ParseInputCommand(string inputCommand)
        {
            CommandData commandData = new();

            SetUserName(inputCommand, commandData);
            SetMessageText(inputCommand, commandData);
            SetTimeStamp(commandData);
            SetProjectName(inputCommand, commandData);
            SetFollowing(inputCommand, commandData);
            SetDisplayWall(inputCommand, commandData);

            commandData.ToString();

            return commandData;
        }

        private static void SetUserName(string inputCommand, CommandData commandData)
        {
            // Is this a message command that contains the user?
            int position = inputCommand.IndexOf("->");
            if (position > 0)
            {
                // The user is the first word before the arrow.
                string[] parts = inputCommand.Split("->");
                commandData.UserName = parts[0].Trim();
            }
        }

        private static void SetMessageText(string inputCommand, CommandData commandData)
        {
            // Is this a message command that contains message text after the associated project?
            int atPosition = inputCommand.IndexOf('@');
            if (atPosition > 0)
            {
                // First space after the project name.
                int spacePositionAfterAt = inputCommand.IndexOf(' ', atPosition);
                string messageText = inputCommand[spacePositionAfterAt..];
                commandData.MessageText = messageText.Trim();
            }
        }

        private static void SetTimeStamp(CommandData commandData)
        {
            commandData.TimeStamp = DateTime.Now;
        }

        private static void SetProjectName(string inputCommand, CommandData commandData)
        {
            // Is this a command that contains a project name prefixed with @?
            int atPosition = inputCommand.IndexOf('@');
            if (atPosition > 0)
            {
                // First space after the project name.
                int spacePositionAfterAt = inputCommand.IndexOf(' ', atPosition);
                string projectName = inputCommand[atPosition..spacePositionAfterAt].Remove(0, 1); // This final command removes the '@'.
                commandData.ProjectName = projectName.Trim();
            }
            else // Or without an @ prefix?
            {
                if (inputCommand.Split(' ').Length == 1) commandData.ProjectName = inputCommand.Trim();
            }
        }

        private static void SetFollowing(string inputCommand, CommandData commandData)
        {
            if (inputCommand.Contains("follows")) commandData.Following = true;
        }

        private static void SetDisplayWall(string inputCommand, CommandData commandData)
        {
            if (inputCommand.Contains("wall")) commandData.DisplayWall = true;
        }
    }
}
