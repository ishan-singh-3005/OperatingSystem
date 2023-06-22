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

        public CommandManager() 
        {
            this.commands = new List<Command>(1)
            {
                new HelpCommand("help"),
                new SysInfoCommand("sysinfo"),
                new ListCommand("ls"),
                new CreateFileCommand("touch"),
                new WriteFileCommand("wrt"),
                new ReadFileCommand("cat"),
                new DeleteFileCommand("rm"),
                new ShutDownCommand("shutdown"),
                new CreateDirectory("mkdir"),
                new RemoveDirectoryCommand("rmd"),
                new ChangeDirectoryCommand("cd"),
                new EditFileCommand("edit")
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
