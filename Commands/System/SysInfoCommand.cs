using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OperatingSystem.Commands.System
{
    public class SysInfoCommand : Command
    {
        public SysInfoCommand(string name, Sys.FileSystem.CosmosVFS fs) : base(name, fs) { }

        public override string execute(string[] args)
        {
            var available_space = fs.GetAvailableFreeSpace(@"0:\");
            var fs_type = fs.GetFileSystemType(@"0:\");

            return "Available Free Space: " + available_space + "\nFile System Type: " + fs_type;
        }
    }
}
