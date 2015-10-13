using System;

namespace Boson.Commands
{
    /// <summary>
    /// Simple command parser which parses commands prefixed with the provided
    /// symbol and parameters separated with the token delimiter.
    /// </summary>
    internal class SimpleCommandParser : ICommandParser
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
            _commandPrefix = commandPrefix;
            _tokenDelimiterCache = new[] { tokenDelimiter };
        }

        /// <summary>
        ///     Parses the command from the provided message and returns a value depicting
        ///     whether the parsing succeeded.
        /// </summary>
        /// <param name="message">Chat message to parse.</param>
        /// <param name="command">Parsed command.</param>
        /// <returns>True if parsing succeeded, otherwise false.</returns>
        public virtual bool TryParse(string message, out string[] command)
        {
            command = null;

            if (!CheckMessageSanity(message))
            {
                return false;
            }

            string untokenizedMessage = message.Substring(_commandPrefix.Length);
            string[] tokens = untokenizedMessage.Split(_tokenDelimiterCache, StringSplitOptions.None);
            command = tokens;

            return true;
        }

        private bool CheckMessageSanity(string message)
        {
            if (message == null)
            {
                return false;
            }
            if (message.Length < _commandPrefix.Length + 1)
            {
                return false;
            }
            if (!message.StartsWith(_commandPrefix))
            {
                return false;
            }
            return true;
        }
    }
}
