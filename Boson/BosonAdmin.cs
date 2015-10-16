// This file is a part of Boson - an administrative plugin for TeknoMW3
// Copyright © 2015 cubrr (jay@thecuber.org)
// Uses InfinityScript, Copyright © 2012 NTA
//
// Boson is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Boson is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Boson.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Diagnostics;
using InfinityScript;
using Boson.Commands;
using Boson.Utility;

namespace Boson
{
    public class BosonAdmin : BaseScript
    {
        private readonly ICommandParser _commandParser;

        private readonly ICommandManager _commandManager;

        public BosonAdmin()
            : this(new SimpleCommandParser(commandPrefix: "!", tokenDelimiter: " "),
                   new CommandManager(new ReflectionProvider(Assembly.GetExecutingAssembly())))
        {
#if DEBUG
            Log.AddListener(new DebugLogListener());
#endif
        }

        public BosonAdmin(ICommandParser parser, ICommandManager manager)
        {
            if (parser == null)
                throw new ArgumentNullException("parser");
            if (manager == null)
                throw new ArgumentNullException("manager");

            _commandParser = parser;
            _commandManager = manager;
        }

        public override EventEat OnSay3(Entity player, ChatType type, string name, ref string message)
        {
            string command;
            IList<string> arguments;

            if (_commandParser.TryParse(message, out command, out arguments))
            {
                //Log.Debug("Command parsed: \"" + command + "\", arguments: " + String.Join(", ", arguments.Select(s => '"' + s + '"')));
                var parameters = new OnSayParameters(this, player, type, arguments);
                return _commandManager.Invoke(command, arguments, parameters);
            }
            return EventEat.EatNone;
        }
    }
}
