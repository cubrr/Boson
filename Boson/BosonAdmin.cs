using System;
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
            string command;
            ICollection<string> arguments;

            if (_commandParser.TryParse(message, out command, out arguments))
            {
                Utilities.RawSayAll("Command parsed: \"" + command + "\", arguments: " + String.Join(", ", arguments.Select(s => '"' + s + '"')));
                return EventEat.EatScript;
            }
            Utilities.RawSayAll("No command detected.");
            return EventEat.EatNone;
        }
    }
}
