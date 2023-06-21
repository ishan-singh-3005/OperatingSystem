using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OperatingSystem.Commands
{
    public class Command
    {
        public readonly String name;
        public Sys.FileSystem.CosmosVFS fs;

        public Command(String name, Sys.FileSystem.CosmosVFS fs) 
        { 
            this.name = name;
            this.fs = fs;
        }

        public virtual String execute(String[] args) { return "";  }
    }
}
