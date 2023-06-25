/*using OperatingSystem.Compressor;*/
using OperatingSystem.Compressor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OperatingSystem.Commands.FileSystem.Files
{


    public class CompressFileCommand : Command
    {
        public CompressFileCommand(string name) : base(name) {        }

        public override string execute(string[] args)
        {
            FileCompressor f = new FileCompressor();
            try
            {
                switch (args[0])
                {
                    case "-c":
                        f.CompressTextFile(args[1], args[2], args[3]);
                        break;
                    case "-d":
                        break;
                    default: return "Invalid flag";
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
