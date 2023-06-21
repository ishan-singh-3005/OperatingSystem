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
        public ReadFileCommand(string name, Sys.FileSystem.CosmosVFS fs) : base(name, fs) { }

        public override string execute(string[] args)
        {
            try
            {
                return File.ReadAllText(Directory.GetCurrentDirectory() + args[0]);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
