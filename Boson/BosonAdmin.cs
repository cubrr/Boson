using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using InfinityScript;
using Boson.Commands;

namespace Boson
{
    public class BosonAdmin : BaseScript
    {
        private readonly ICommandParser _commandParser = new SimpleCommandParser(commandPrefix: "!", tokenDelimiter: " ");

        public BosonAdmin()
        {
            
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

    internal struct OnSayParameters
    {
        public Entity Caller { get; private set; }

        public BaseScript.ChatType ChatType { get; private set; }

        public ICollection<string> Arguments { get; private set; }

        public OnSayParameters(Entity caller, BaseScript.ChatType chatType, ICollection<string> args)
            : this()
        {
            Caller = caller;
            ChatType = chatType;
            Arguments = args;
        }
    }
}
