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
    /// Represents a command usable by server clients.
    /// </summary>
    public class Command : IEquatable<Command>
    {
        /// <summary>
        /// Gets the action of the command.
        /// </summary>
        /// <value>The action of the command.</value>
        private readonly Action<CommandInvokationContext> _action;

        /// <summary>
        /// Gets the amount of arguments supported by this command. Value is -1 if the command supports variable arguments.
        /// This property dictates the minimum amount of words in a <see cref="ProjectBoson.ChatMessage"/> accepted.
        /// </summary>
        /// <value>The amount of arguments supported or -1 if the amoun is variable.</value>
        public virtual int ArgCount { get; protected set; }

        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>The name of the command.</value>
        public virtual string Name { get; protected set; }

        /// <summary>
        /// Gets the description of the command.
        /// </summary>
        /// <value>The description of the command.</value>
        public virtual string Description { get; protected set; }

        public Command()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectBoson.Commands.Command"/> class.
        /// </summary>
        /// <param name="name">Name of the command. If the command is <c>!kick</c>, the name is <c>kick</c>.</param>
        /// <param name="argCount">Amount of arguments supported</param>
        /// <param name="description">Description of the command for use in <c>!help</c>.</param> 
        /// <param name="action">Action to be performed when this command is invoked.</param>
        public Command(string name, string description, int argCount, Action<CommandInvokationContext> action)
        {
            _action = action;
            ArgCount = argCount;
            Name = name;
            Description = description;
        }

        /// <inheritdoc/>
        public virtual void Invoke(CommandInvokationContext context)
        {
            _action(context);
        }

        /// <summary>
        /// Determines whether the specified <see cref="ProjectBoson.Commands.Command"/> is equal to the current <see cref="ProjectBoson.Commands.Command"/>.
        /// Compares <see cref="Command.Name"/> and <see cref="Command.Description"/>.
        /// </summary>
        /// <param name="other">The <see cref="ProjectBoson.Commands.Command"/> to compare with the current <see cref="ProjectBoson.Commands.Command"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ProjectBoson.Commands.Command"/> is equal to the current
        /// <see cref="ProjectBoson.Commands.Command"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(Command other)
        {
            if (Object.ReferenceEquals(other, null))
                return false;
            if (Object.ReferenceEquals(this, other))
                return true;
            return     ArgCount == other.ArgCount &&
                String.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase) &&
                String.Equals(Description, other.Description, StringComparison.Ordinal);
        }

        #region Object overrides

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;
            var other = obj as Command;
            return !Object.ReferenceEquals(other, null) &&
                Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 2796203;
                hash = hash * 1114111 + ArgCount.GetHashCode();
                hash = hash * 1114111 + Name.GetHashCode();
                hash = hash * 1114111 + Description.GetHashCode();
                return hash;
            }
        }

        #endregion
    }
}
