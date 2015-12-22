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
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Boson. If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Boson.Api;
using Boson.Api.Commands;
using Boson.Commands;
using Boson.Utility;
using InfinityScript;

namespace Boson
{
    public class BosonAdmin : BaseScript
    {
        private readonly ICommandParser _commandParser;

        private readonly ICommandRepository _commandRepository;

        public BosonAdmin()
            : this(new SimpleCommandParser(commandPrefix: "!", tokenDelimiter: " "),
                   new CommandRepository(new ReflectionCommandProvider(Assembly.GetExecutingAssembly())))
        {
#if DEBUG
            Log.AddListener(new DebugLogListener());
#endif
        }

        public BosonAdmin(ICommandParser parser, ICommandRepository repository)
        {
            if (parser == null)
            {
                throw new ArgumentNullException("parser");
            }

            if (repository == null)
            {
                throw new ArgumentNullException("manager");
            }

            _commandParser = parser;
            _commandRepository = repository;
        }

        public override EventEat OnSay3(Entity player, ChatType type, string name, ref string message)
        {
            string commandName;
            IList<string> arguments;

            if (!_commandParser.TryParse(message, out commandName, out arguments))
            {
                // Not a command, assume normal message
                Log.Debug("No command parsed from message by {0}.", player.Name);
                // return EventEat.EatGame if the player is muted!
                return EventEat.EatNone;
            }

            Log.Debug("Command parsed from message by {0}! Command: {1}; arguments: {2}",
                      player.Name,
                      commandName,
                      String.Join(", ", arguments));

            var chatMessage = new CommandInvokationContext(this, player, type, message);
            string exceptionMessage;
            BaseScript.EventEat returnValue = CallCommand(commandName, arguments, chatMessage, out exceptionMessage);

            if (exceptionMessage != null)
            {
                // TODO: Send response to remote user? Not in this method though...
                Utilities.RawSayTo(player, exceptionMessage);
            }

            return returnValue;
        }
        
        public BaseScript.EventEat CallCommand(string commandName, IList<string> arguments, CommandInvokationContext message, out string exceptionMessage)
        {
            // TODO: Maybe some day we can call commands remotely
            exceptionMessage = null;

            ICommand command;
            if (!_commandRepository.TryGetCommand(commandName, out command))
            {
                exceptionMessage = String.Format("Command {0} not found!", commandName);
                return EventEat.EatGame;
            }

            // TODO: Check user's command permissions here
            EventEat result = command.Invoke(arguments, message);

            return result;
        }
    }
}
