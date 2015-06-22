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

namespace ProjectBoson.Commands
{
	/// <summary>
	/// Alias for a command. Holds a reference to the real command and usess that instance for invokations.
	/// </summary>
	public sealed class CommandAlias : Command
	{
		private readonly Command _aliasOf;

		/// <summary>
		/// Gets the amount of arguments taken by the command whose alias the CommandAlias is.
		/// Value is -1 if the command takes a variable amount of arguments. 
		/// </summary>
		/// <value>The amount of arguments or -1 if variable arguments are supported.</value>
		public override int ArgCount { get { return _aliasOf.ArgCount; } }

		/// <summary>
		/// Gets the description of the command whose alias the CommandAlias is.
		/// </summary>
		/// <value>The description of the command.</value>
		public override string Description { get { return _aliasOf.Description; } }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProjectBoson.Commands.CommandAlias"/> class.
		/// </summary>
		/// <param name="alias">Alias.</param>
		/// <param name="command">Command whose alias is to be created.</param>
		public CommandAlias(string alias, Command command)
		{
			Name = alias;
			_aliasOf = command;
		}

		/// <inheritdoc></inheritdoc>
		/// <summary>
		/// Invokes the command whose alias this instance is.
		/// </summary>
		/// <param name="context">Context for the invokation.</param>
		public override void Invoke(CommandInvokationContext context)
		{
			_aliasOf.Invoke(context);
		}
	}
}

