using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys = Cosmos.System;
using System.Threading.Tasks;
using System.IO;

namespace OperatingSystem.Commands.FileSystem.Directories
{
    public class ChangeDirectoryCommand : Command
    {
        public ChangeDirectoryCommand(string name) : base(name) { }

        public override string execute(string[] args)
        {
            try
            {
                var currdir = Directory.GetCurrentDirectory();
                if (args[0] == "~")
                {
                    Directory.SetCurrentDirectory("");
                }
                else
                {
                    Directory.SetCurrentDirectory(currdir + args[0]);
                }
                return "";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
