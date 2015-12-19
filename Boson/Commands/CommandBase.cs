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
using Boson.Api;
using Boson.Api.Commands;
using InfinityScript;

namespace Boson.Commands
{
    /// <summary>
    /// Base class for all commands. Provides properties for the name and
    /// aliases, and methods for invoking the command and getting usage help.
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        private static readonly string[] EmptyAliasList = new string[0];

        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the aliases of the command.
        /// </summary>
        public virtual IEnumerable<string> Aliases
        {
            get { return EmptyAliasList; }
        }

        public abstract BaseScript.EventEat Invoke(IList<string> commandParams, OnSayParameters context);

        public abstract void PrintHelp(IList<string> commandParams, OnSayParameters context);
    }
}
