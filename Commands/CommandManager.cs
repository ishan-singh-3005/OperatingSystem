using OperatingSystem.Commands.FileSystem;
using OperatingSystem.Commands.FileSystem.Files;
using OperatingSystem.Commands.FileSystem.Directories;
using OperatingSystem.Commands.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OperatingSystem.Commands
{
    class CommandManager
    {
        private List<Command> commands;

        public CommandManager(Sys.FileSystem.CosmosVFS fs) 
        {
            this.commands = new List<Command>(1)
            {
                new HelpCommand("help", fs),
                new SysInfoCommand("sysinfo", fs),
                new ListCommand("ls", fs),
                new CreateFileCommand("touch", fs),
                new WriteFileCommand("wrt", fs),
                new ReadFileCommand("cat", fs),
                new DeleteFileCommand("rm", fs),
                new ShutDownCommand("shutdown", fs),
                new CreateDirectory("mkdir", fs),
                new RemoveDirectoryCommand("rmd", fs),
                new ChangeDirectoryCommand("cd", fs)
            };
        }

        public String processInput (String input) 
        {
            String[] split = input.Split(' ');
            String label = split[0];

            List<String> args = new List<String>();

            int ctr = 0;
            foreach (String s in split)
            {
                if (ctr!=0) {
                    args.Add(s);
                }
                ++ctr;
            }

            foreach (Command cmd in this.commands) { 
                if (cmd.name.Equals(label))
                {
                    return cmd.execute(args.ToArray());
                }
            }

            return "Your command \"" + label + "\" does not exist";
        }
    }
}
