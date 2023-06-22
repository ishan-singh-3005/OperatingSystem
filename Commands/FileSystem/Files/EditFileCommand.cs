using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OperatingSystem.Commands.FileSystem
{
    public class EditFileCommand : Command
    {
        public EditFileCommand(string name) : base(name) { }

        public override string execute(string[] args)
        {
            OperatingSystem.FileEditor.FileEditor.StartMIV();
            return "";
        }
    }
}
