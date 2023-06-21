using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OperatingSystem.Commands.FileSystem.Files
{
    public class CreateFileCommand : Command
    {
        public CreateFileCommand(string name) : base(name) { }

        public override string execute(string[] args)
        {
            try
            {
                var file_stream = Sys.FileSystem.VFS.VFSManager.CreateFile(args[0]);
                return "Your file " + args[0] + " was created";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
