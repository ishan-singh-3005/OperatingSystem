﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OperatingSystem.Commands.FileSystem
{
    public class WriteFileCommand : Command
    {
        public WriteFileCommand(string name, Sys.FileSystem.CosmosVFS fs) : base(name, fs) { }

        public override string execute(string[] args)
        {
            try
            {
                File.WriteAllText(Directory.GetCurrentDirectory() + args[0], string.Join("", args.Skip(1).ToArray()));
                return "Successfully updated " + args[0];
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}