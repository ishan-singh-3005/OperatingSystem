using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OperatingSystem.Commands.System
{
    public class HelpCommand : Command
    {
        public HelpCommand(string name) : base(name) { }

        public override string execute(string[] args)
        {
            return "Welcome to AmogOS.";
        }
    }
}
