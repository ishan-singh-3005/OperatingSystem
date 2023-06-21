using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OperatingSystem.Commands.FileSystem
{
    public class WriteFileCommand : Command
    {
        public WriteFileCommand(string name) : base(name) { }

        public override string execute(string[] args)
        {
            try
            {
                if (Sys.FileSystem.VFS.VFSManager.FileExists(args[0]))
                {
                    File.WriteAllText(args[0], string.Join("", args.Skip(1).ToArray()));
                    return "Successfully updated " + args[0];
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
