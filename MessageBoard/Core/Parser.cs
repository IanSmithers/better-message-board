namespace MessageBoard.Core
{
    public struct InputCommand
    {
        public string UserName { get; set; }
        public string MessageText { get; set; }
        public DateTime TimeStamp { get; set; }
        public string ProjectName { get; set; }
        public bool Following { get; set; }
        public bool DisplayWall { get; set; }

        public override readonly string ToString()
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
        public static InputCommand ParseInputCommand(string inputCommand)
        {
            // TODO Will parse input commands and pull out pertinent data (user/message/project/follow/wall).
            // Something like this:
            return new InputCommand()
            {
                UserName = "Foo",
                MessageText = "Bar",
                TimeStamp = DateTime.Now,
                ProjectName = "Moonshot",
                Following = false,
                DisplayWall = false
            };
        }
    }
}
