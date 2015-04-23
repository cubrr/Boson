using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBoson.Commands
{
    public class CommandManager
    {
        public SortedDictionary<string, Command> Commands { get; private set; }

        public CommandManager()
        {
            Commands = new SortedDictionary<string, Command>();
        }
    }
}
