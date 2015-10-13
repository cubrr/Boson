using System;

namespace Boson.Commands
{
    internal abstract class SimpleCommandParser : ICommandParser
    {
        private readonly string _commandPrefix;

        // TODO: Clean below if unused
        //private readonly string _tokenDelimiter;

        /// <summary>
        ///     Cache instance of the delimiter for use with String.Split
        /// </summary>
        private readonly string[] _tokenDelimiterCache;

        protected SimpleCommandParser(string commandPrefix, string tokenDelimiter)
        {
            _commandPrefix = commandPrefix;
            // TODO: Clean below if unused
            //_tokenDelimiter = tokenDelimiter;
            _tokenDelimiterCache = new[] { tokenDelimiter };
        }

        /// <summary>
        ///     Checks the sanity of the command message.
        /// </summary>
        /// <param name="message">Chat message to check.</param>
        /// <returns>
        ///     <see langword="false"/> if message is null, shorter than the minimum
        ///     allowed command length, or doesn't start with the correct command prefix.
        ///     Otherwise <see langword="true"/>
        /// </returns>
        protected virtual bool CheckMessageSanity(string message)
        {
            // if someone wants to extend this...who am I to stop you?
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
    }
}