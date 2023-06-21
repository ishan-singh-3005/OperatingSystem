using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OperatingSystem.Commands.FileSystem
{
    public class ReadFileCommand : Command
    {
        public ReadFileCommand(string name) : base(name) { }

        public override string execute(string[] args)
        {
            try
            {
                if (Sys.FileSystem.VFS.VFSManager.FileExists(@"0:" + Directory.GetCurrentDirectory() + "\\" + args[0]))
                {
                    return File.ReadAllText(args[0]);
                }
                else
                {
                    return "Error while writing to file";
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
