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
        public CreateDirectory(string name, Sys.FileSystem.CosmosVFS fs) : base(name, fs) { }

        public override string execute(string[] args)
        {
            try
            {
                if (Directory.Exists((Directory.GetCurrentDirectory() + args[0]))){
                    return "Directory exists";
                }
                var file_stream = Directory.CreateDirectory(Directory.GetCurrentDirectory() + args[0]);
                return "Your directory " + args[0] + " was created";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
