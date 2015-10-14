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
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using InfinityScript;

namespace Boson.Commands
{
    /// <summary>
    /// Simple command parser which parses case-insensitive commands prefixed with the provided
    /// symbol and parameters separated with the token delimiter.
    /// </summary>
    public class SimpleCommandParser : ICommandParser
    {
        private readonly string _commandPrefix;

        /// <summary>
        ///     Cache instance of the delimiter for use with String.Split
        /// </summary>
        private readonly string[] _tokenDelimiterCache;

        protected SimpleCommandParser()
        {
        }

        public SimpleCommandParser(string commandPrefix, string tokenDelimiter)
        {
            if (String.IsNullOrEmpty(commandPrefix))
                throw new ArgumentNullException("commandPrefix");
            if (String.IsNullOrEmpty(tokenDelimiter))
                throw new ArgumentNullException("tokenDelimiter");
            // TODO: Figure out max length of chat message. Neither prefix nor delimiter can be longer than max - 1.
            
            _commandPrefix = commandPrefix;
            _tokenDelimiterCache = new[] { tokenDelimiter };
        }

        /// <summary>
        ///     Parses the command from the provided message and returns a value depicting
        ///     whether the parsing succeeded.
        /// </summary>
        /// <param name="message">Chat message to parse.</param>
        /// <param name="command">Parsed command.</param>
        /// <param name="arguments">Parsed command arguments.</param>
        /// <returns>True if parsing succeeded, otherwise false.</returns>
        public virtual bool TryParse(string message, out string command, out IList<string> arguments)
        {
            command = null;
            arguments = null;

            if (!CheckMessageSanity(message))
            {
                return false;
            }

            string untokenizedMessage = message.Substring(_commandPrefix.Length);
            var tokens = new List<string>(untokenizedMessage.Split(_tokenDelimiterCache, StringSplitOptions.None));

            command = tokens[0].ToLower();
            tokens.RemoveAt(0);
            arguments = tokens;

            return true;
        }

        private bool CheckMessageSanity(string message)
        {
            bool ret = message != null
                       && message.Length >= _commandPrefix.Length + 1
                       && message.StartsWith(_commandPrefix);
            return ret;
        }
    }
}
