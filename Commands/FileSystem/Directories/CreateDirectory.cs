using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys = Cosmos.System;
using System.Threading.Tasks;
using System.IO;

namespace OperatingSystem.Commands.FileSystem.Directories
{
    public class CreateDirectory : Command
    {
        public CreateDirectory(string name) : base(name) { }

        public override string execute(string[] args)
        {
            try
            {
                var file_stream = Sys.FileSystem.VFS.VFSManager.CreateDirectory(@"0:" + Directory.GetCurrentDirectory() + "\\" + args[0]);
                return "Your directory " + args[0] + " was created";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
