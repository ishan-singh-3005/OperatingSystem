using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using OperatingSystem.Commands;
using System.IO;
using Cosmos.System.FileSystem;

namespace OperatingSystem
{
    public class Kernel : Sys.Kernel
    {
        private CommandManager commandManager;
        private CosmosVFS vfs;        

        protected override void BeforeRun()
        {
            this.vfs= new CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(this.vfs);
            Console.WriteLine("AmongOS booted successfully.");
            this.commandManager= new CommandManager();
        }

        protected override void Run()
        {
            string dir = Directory.GetCurrentDirectory();
            Console.Write("~/" + dir + "> ");
            String reponse;
            var input = Console.ReadLine();
            reponse = this.commandManager.processInput(input);
            Console.WriteLine(reponse);
            
        }
    }
}
