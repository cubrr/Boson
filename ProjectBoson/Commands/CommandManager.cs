// Copyright (c) 2015 Joona Heikkilä
//
// This file is part of Boson.
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
// along with Foobar.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBoson.Commands
{
    /// <summary>
    /// Manages the server client commands.
    /// </summary>
    public sealed class CommandManager
    {
        private readonly Dictionary<string, Command> _commands;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectBoson.Commands.CommandManager"/> class.
        /// </summary>
        public CommandManager()
        {
            _commands = new Dictionary<string, Command>();
        }

        /// <summary>
        /// Adds the specified command to the command dictionary.
        /// </summary>
        /// <param name="command">Command to add.</param>
        public void Add(Command command)
        {
            if (String.IsNullOrWhiteSpace(command.Name))
                throw new ArgumentNullException("command", "Command's name cannot be null, empty or consist only of whitespace characters!");
            if (command.Description == null)
                throw new ArgumentNullException("command", "Command description cannot be null!");
            
            _commands[command.Name] = command;
        }

        /// <summary>
        /// Adds multiple commands to the command dictionary.
        /// </summary>
        /// <param name="commands">Commands to add.</param>
        public void AddRange(IEnumerable<Command> commands)
        {
            if (commands == null)
                throw new ArgumentNullException("commands");
            
            foreach (var command in commands)
            {
                Add(command);
            }
        }

        /// <summary>
        /// Tries to get the command with the specified <paramref name="name"/> and invokes it with the
        /// specified <paramref name="context"/>. Returns <c>true</c> if command was found and invoked, <c>false</c>
        /// if the command was not found.
        /// </summary>
        /// <returns><c>true</c>, if command was invoked, <c>false</c> otherwise.</returns>
        /// <param name="name">Name of the command to invoke.</param>
        /// <param name="context">Context for the invokation.</param>
        public bool InvokeCommand(string name, CommandInvokationContext context)
        {
            Command command = this[name];
            if (command == null)
                return false;
            command.Invoke(context);
            return true;
        }

        /// <inheritdoc/>
        private Command this[string key]
        {
            get 
            {
                Command command;
                return !_commands.TryGetValue(key, out command) ? null : command;
            }
            set
            {
                _commands[key] = value;
            }
        }
    }
}
