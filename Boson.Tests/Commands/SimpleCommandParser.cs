using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boson.Commands;
// ReSharper disable All

namespace Boson.Tests.Commands
{
    [TestClass]
    public class SimpleCommandParserTests
    {
        [TestClass]
        public class Constructors
        {
            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void NullPrefix_ThrowsException()
            {
                new SimpleCommandParser(null, " ");
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void EmptyPrefix_ThrowsException()
            {
                new SimpleCommandParser("", " ");
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void NullTokenDelimiter_ThrowsException()
            {
                new SimpleCommandParser("!", null);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void EmptyTokenDelimiter_ThrowsException()
            {
                new SimpleCommandParser("!", "");
            }

            [TestMethod]
            public void SingleCharacterParameters_Work()
            {
                new SimpleCommandParser("!", " ");
            }

            [TestMethod]
            public void MultiCharacterParameters_Work()
            {
                new SimpleCommandParser("!!", " ; ");
            }

            [TestMethod]
            public void OnlyWhiteSpaceSingleCharacterParameters_Work()
            {
                new SimpleCommandParser(" ", " ");
            }

            [TestMethod]
            public void OnlyWhiteSpaceMultiCharacterParameters_Work()
            {
                new SimpleCommandParser("    ", "     ");
            }
        }

        [TestClass]
        public class TryParseMethod
        {
            private const string ShortParserPrefix = "!";
            private const string ShortParserDelimiter = " ";
            private const string LongParserPrefix = "<!--";
            private const string LongParserDelimiter = "..;..";
            private readonly string[] _commands = new[]
            {
                "s", "test", "debug", "superman", "kick", "ban", "ac130superdupercoolparty"
            };

            private SimpleCommandParser _shortParser;
            private SimpleCommandParser _longParser;
            private string _outCommand;
            private IList<string> _outParams;

            [TestInitialize]
            public void TryParseInitialization()
            {
                _shortParser = new SimpleCommandParser(ShortParserPrefix, ShortParserDelimiter);
                _longParser = new SimpleCommandParser(LongParserPrefix, LongParserDelimiter);
            }

            [TestMethod]
            public void NullMessage_ReturnsFalse()
            {
                bool result = _shortParser.TryParse(null, out _outCommand, out _outParams);
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void EmptyMessage_ReturnsFalse()
            {
                bool result = _shortParser.TryParse("", out _outCommand, out _outParams);
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void MessageShorterThanShortPrefix_ReturnsFalse()
            {
                bool result = _shortParser.TryParse(" ", out _outCommand, out _outParams);
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void MessageShorterThanLongPrefix_ReturnsFalse()
            {
                bool result = _longParser.TryParse(" ", out _outCommand, out _outParams);
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void ShortPrefixedEmptyCommand_ReturnsFalse()
            {
                bool result = _shortParser.TryParse(ShortParserPrefix, out _outCommand, out _outParams);
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void LongPrefixedEmptyCommand_ReturnsFalse()
            {
                bool result = _longParser.TryParse(LongParserPrefix, out _outCommand, out _outParams);
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void ShortPrefixedCommandsWithoutArgs_ReturnsTrue()
            {
                foreach (string command in _commands)
                {
                    string prefixedCommand = ShortParserPrefix + command;
                    bool result = _shortParser.TryParse(prefixedCommand, out _outCommand, out _outParams);
                    Assert.IsTrue(result);
                }
            }

            [TestMethod]
            public void LongPrefixedCommandsWithoutArgs_ReturnsTrue()
            {
                foreach (string command in _commands)
                {
                    string prefixedCommand = LongParserPrefix + command;
                    bool result = _longParser.TryParse(prefixedCommand, out _outCommand, out _outParams);
                    Assert.IsTrue(result);
                }
            }

            [TestMethod]
            public void ShortPrefixedCommandsWithoutArgs_ParsesCommand()
            {
                foreach (string command in _commands)
                {
                    string prefixedCommand = ShortParserPrefix + command;
                    bool result = _shortParser.TryParse(prefixedCommand, out _outCommand, out _outParams);
                    Assert.AreEqual(command, _outCommand);
                }
            }
        }
    }
}
