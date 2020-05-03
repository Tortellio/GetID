using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetID.Commands
{
    public class CommandGetID : IRocketCommand
    {
        public string Name => "getid";
        public string Help => "Get specified IDs";
        public string Syntax => "";
        public List<string> Aliases => new List<string>() { "gid" };
        public List<string> Permissions => new List<string>() { "getid" };
        public AllowedCaller AllowedCaller => AllowedCaller.Both;
        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length != 2) return;
            switch (command[0])
            {
                case "item": GetID.Instance.GetItemID(command[1]); break;
                case "vehicle": GetID.Instance.GetVehicleID(command[1]); break;
                case "resource": GetID.Instance.GetResourceID(command[1]); break;
                case "animal": GetID.Instance.GetItemID(command[1]); break;
            }
        }
    }
}
