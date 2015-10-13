﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;
using Boson.Commands;

namespace Boson
{
    public class BosonAdmin : BaseScript
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private ICommandParser _commandParser;

        public BosonAdmin()
        {
            _commandParser = new SimpleCommandParser(commandPrefix: "!", tokenDelimiter: " ");
        }

        public override EventEat OnSay3(Entity player, ChatType type, string name, ref string message)
        {
            // TODO: Create own class for commands
            string[] command;
            ICollection<string> arguments;

            if (_commandParser.TryParse(message, out command, out ICollection<string> arguments))
            {
                // use command
                return EventEat.EatScript;
            }
            return EventEat.EatNone;
        }
    }
}
