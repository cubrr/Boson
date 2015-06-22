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
using InfinityScript;

namespace ProjectBoson
{
	public class ChatMessage
	{
		/// <summary>
		/// Gets the type of the chat where the message originates from.
		/// </summary>
		/// <value>The type of the chat.</value>
		public BaseScript.ChatType ChatType { get; private set; }

		/// <summary>
		/// Gets the chat message as-is.
		/// </summary>
		/// <value>The unmodified chat message.</value>
		public string Message { get; private set; }

		/// <summary>
		/// Gets the string array containing the message's words.
		/// This array is the result of <see cref="String.Split(char[])"/> by whitespace.
		/// </summary>
		/// <value>The words of the message.</value>
		public string[] Words { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProjectBoson.ChatMessage"/> class.
		/// </summary>
		/// <param name="message">Chat message.</param>
		/// <param name="chatType">Type of the chat.</param>
		public ChatMessage(string message, BaseScript.ChatType chatType)
		{
			Message = message;
			Words = message.Split(' ');
		}
	}
}

