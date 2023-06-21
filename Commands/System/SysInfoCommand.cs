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
        public SysInfoCommand(string name) : base(name) { }

        public override string execute(string[] args)
        {
            var available_space = Sys.FileSystem.VFS.VFSManager.GetAvailableFreeSpace(@"0:\");

            return "Available Free Space: " + available_space;
        }
    }
}
