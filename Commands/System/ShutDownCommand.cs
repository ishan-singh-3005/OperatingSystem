using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OperatingSystem.Commands.System
{
    public class ShutDownCommand : Command
    {
        public ShutDownCommand(string name, Sys.FileSystem.CosmosVFS fs) : base(name, fs) { }

        public override string execute(string[] args)
        {
            Console.WriteLine("Powering off...");
            Thread.Sleep(2000);
            Sys.Power.Shutdown();
            return "";
        }
    }
}
