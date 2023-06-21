using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OperatingSystem.Commands.FileSystem
{
    public class ListCommand : Command
    {
        public ListCommand(string name, Sys.FileSystem.CosmosVFS fs) : base(name, fs) { }

        public override string execute(string[] args)
        {
            string[] directory_list;
            string[] file_list;
            if (args.Length == 0)
            {
                file_list = Directory.GetFiles(@"0:\" + Directory.GetCurrentDirectory());
                directory_list = Directory.GetDirectories(@"0:\" + Directory.GetCurrentDirectory());
                string dirs = string.Join("(d)\t", directory_list);
                string files = string.Join("\t", file_list);
                return dirs + "(d)\t" + files;
            }
            else
            {
                switch (args[0])
                {
                    case "--help":
                        return "Get a list of files and directories";
                    default:
                        if (!Directory.Exists(@"0:\" + Directory.GetCurrentDirectory() + args[0]))
                        {
                            return "Directory does not exist";
                        }
                        else
                        {
                            file_list = Directory.GetFiles(@"0:\" + Directory.GetCurrentDirectory() + args[0]);
                            directory_list = Directory.GetDirectories(@"0:\" + Directory.GetCurrentDirectory() + args[0]);
                            string files = string.Join("\t", file_list);
                            string dirs = string.Join("(d)\t", directory_list);
                            return dirs + "(d)\t" + files;
                        }
                }
            }
        }
    }

}
