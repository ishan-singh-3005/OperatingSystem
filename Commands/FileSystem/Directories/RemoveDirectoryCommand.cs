using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys = Cosmos.System;
using System.Threading.Tasks;
using System.IO;

namespace OperatingSystem.Commands.FileSystem.Directories
{
    public class RemoveDirectoryCommand : Command
    {
        public RemoveDirectoryCommand(string name) : base(name) { }

        public override string execute(string[] args)
        {
            try
            {
                Sys.FileSystem.VFS.VFSManager.DeleteDirectory(@"0:" + Directory.GetCurrentDirectory() + "\\" + args[0], true);
             
                return "Your directory " + args[0] + " was removed";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
