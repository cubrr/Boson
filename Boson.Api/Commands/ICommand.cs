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
using InfinityScript;

namespace Boson.Api.Commands
{
    /// <summary>
    /// Represents an invokable player command.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }

        /// <summary>
        /// Gets the description of the command.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        /// <remarks>
        /// <note type="important">
        /// Implementations should keep the description as compact as possible,
        /// as the value is printed to the in-game chat.
        /// </note>
        /// </remarks>
        string Description { get; }

        /// <summary>
        /// Gets usage help for the command.
        /// </summary>
        /// <value>
        /// The usage help.
        /// </value>
        /// <remarks>
        /// <note type="important">
        /// Implementations should keep the description as compact as possible,
        /// as the value is printed to the in-game chat.
        /// </note>
        /// </remarks>
        string Usage { get; }

        /// <summary>
        /// Gets the aliases of the command.
        /// </summary>
        /// <value>
        /// The aliases.
        /// </value>
        IEnumerable<string> Aliases { get; }

        /// <summary>
        /// Invokes the command with the specified command parameters and
        /// message context, and returns the command's requested
        /// <see cref="BaseScript.EventEat"/> return value 
        /// </summary>
        /// <param name="commandParams">The command parameters.</param>
        /// <param name="context">The message context.</param>
        /// <returns>A <see cref="BaseScript.EventEat"/> enum value.</returns>
        BaseScript.EventEat Invoke(IList<string> commandParams, CommandMessage context);
    }
}
