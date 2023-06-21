using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OperatingSystem.Commands.FileSystem
{
    public class DeleteFileCommand : Command
    {
        public DeleteFileCommand(string name) : base(name) { }

        public override string execute(string[] args)
        {
            try
            {
                Sys.FileSystem.VFS.VFSManager.DeleteFile(@"0:" + Directory.GetCurrentDirectory() + "\\" + args[0]);
                return "Successfully deleted file " + args[0];
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
