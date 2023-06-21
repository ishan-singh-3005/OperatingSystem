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
        public CreateFileCommand(string name, Sys.FileSystem.CosmosVFS fs) : base(name, fs) { }

        public override string execute(string[] args)
        {
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "/" + args[0]))
                {
                    return "File exists";
                }
                var file_stream = File.Create(Directory.GetCurrentDirectory() + args[0]);
                return "Your file " + args[0] + " was created";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
