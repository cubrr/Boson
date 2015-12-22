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
using System.Linq;
using System.Reflection;
using System.Text;
using Boson.Api;
using Boson.Api.Commands;
using InfinityScript;

namespace Boson.Commands
{
    public partial class CommandRepository : ICommandRepository
    {
        private readonly IDictionary<string, CommandRepositoryEntry> _commands;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRepository"/> class using the
        /// specified command provider.
        /// </summary>
        /// <param name="provider">Command provider used for fetching commands.</param>
        public CommandRepository(ICommandProvider provider)
        {
            // Command names should be processed ignoring the case
            _commands = new Dictionary<string, CommandRepositoryEntry>(StringComparer.CurrentCultureIgnoreCase);
            AddCommandsAndAliases(_commands, provider.GetCommands());
        }

        /// <summary>
        /// Gets the command matching the specified name. A return value
        /// indicates whether the lookup succeeded or failed.
        /// </summary>
        /// <param name="commandName">Name of the command to get.</param>
        /// <param name="command">
        /// When this method returns, contains the requested command if the
        /// lookup succeeded, or null if the lookup failed.
        /// </param>
        /// <returns>Indicates whether the lookup succeeded or failed.</returns>
        public bool TryGetCommand(string commandName, out ICommand command)
        {
            CommandRepositoryEntry entry;
            if (!_commands.TryGetValue(commandName, out entry))
            {
                command = null;
                return false;
            }

            command = entry.Command;
            return true;
        }

        private static void AddCommandsAndAliases(IDictionary<string, CommandRepositoryEntry> dict, IEnumerable<ICommand> commands)
        {
            foreach (ICommand command in commands)
            {
                AddCommand(dict, command.Name, command, false);
                foreach (string alias in command.Aliases)
                {
                    AddCommand(dict, alias, command, true);
                }
            }
        }

        private static void AddCommand(IDictionary<string, CommandRepositoryEntry> dict, string key, ICommand command, bool isAlias)
        {
            CommandRepositoryEntry existingInstance;
            if (dict.TryGetValue(key, out existingInstance))
            {
                Log.Write(LogLevel.Warning,
                          "Existing command {0} [{1}] replaced by identically named or aliased [{2}]!",
                          key,
                          existingInstance.Command.GetType(),
                          command.GetType());
            }

            dict[key] = new CommandRepositoryEntry(command, isAlias);
        }

        #region CommandRepositoryEntry

        private struct CommandRepositoryEntry
        { 
            public ICommand Command;

            public bool IsAlias;

            public CommandRepositoryEntry(ICommand cmd, bool isAlias)
            {
                Command = cmd;
                IsAlias = isAlias;
            }
        }

        #endregion
    }
}
