﻿// This file is a part of Boson - an administrative plugin for TeknoMW3
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
using System.Reflection;
using System.Text;
using InfinityScript;
using Boson.Api;
using Boson.Api.Commands;

namespace Boson.Commands
{
    public class CommandRepository : ICommandRepository
    {
        private readonly IDictionary<string, ICommand> _commands;

        public CommandRepository(ICommandProvider provider)
        {
            _commands = provider.GetCommands();
        }

        public bool FindCommand(string commandName, out ICommand command)
        {
            return _commands.TryGetValue(commandName, out command);
        }
    }
}