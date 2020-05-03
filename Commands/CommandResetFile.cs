using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;

namespace GetID.Commands
{
    public class CommandResetFile : IRocketCommand
    {
        public string Name => "resetfile";
        public string Help => "Clear files";
        public string Syntax => "[detailed]";
        public List<string> Aliases => new List<string>() { "resetfile" };
        public List<string> Permissions => new List<string>() { "resetfile" };
        public AllowedCaller AllowedCaller => AllowedCaller.Both;
        public void Execute(IRocketPlayer caller, string[] command)
        {
            GetID.Instance.ResetFile();
        }
    }
}
