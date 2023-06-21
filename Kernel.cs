using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using OperatingSystem.Commands;
using System.IO;

namespace OperatingSystem
{
    public class Kernel : Sys.Kernel
    {
        private CommandManager commandManager;
        
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Console.WriteLine("AmongOS booted successfully.");
            this.commandManager= new CommandManager(fs);
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
