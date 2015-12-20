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
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Boson. If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boson.Commands;
using Boson.Tests.Commands.Mock;

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
            public void ParameterlessConstructor_NoException()
            {
                new SimpleCommandParserDerivingMock();
            }

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
            public void WhiteSpaceOnlySingleCharacterParameters_Work()
            {
                new SimpleCommandParser(" ", " ");
            }

            [TestMethod]
            public void WhiteSpaceOnlyMultiCharacterParameters_Work()
            {
                new SimpleCommandParser("    ", "     ");
            }
        }

        [TestClass]
        public class TryParseMethod
        {
            private const string CommandArgument1 = "cubrr";
            private const string CommandArgument2 = "hax";
            private const string ParserPrefix = "!";
            private const string ParserDelimiter = " ";
            private readonly string[] _commands = new[]
            {
                "!", "!!", "s", "test", "debug", "superman", "kick", "ban", "ac130superdupercoolparty", "äiköåÖöãéèô"
            };

            private SimpleCommandParser _parser;
            private string _outCommand;
            private IList<string> _outParams;

            public TryParseMethod()
            {
                _parser = new SimpleCommandParser(ParserPrefix, ParserDelimiter);
            }

            [TestMethod]
            public void NullMessage_ReturnsFalse()
            {
                bool result = _parser.TryParse(null, out _outCommand, out _outParams);
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void EmptyMessage_ReturnsFalse()
            {
                bool result = _parser.TryParse(String.Empty, out _outCommand, out _outParams);
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void MessageShorterThanPrefix_ReturnsFalse()
            {
                bool result = _parser.TryParse(" ", out _outCommand, out _outParams);
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void PrefixedEmptyCommand_ReturnsFalse()
            {
                bool result = _parser.TryParse(ParserPrefix, out _outCommand, out _outParams);
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void CommandsWithoutArgs_ReturnTrue()
            {
                foreach (string command in _commands)
                {
                    string prefixedCommand = ParserPrefix + command;
                    bool result = _parser.TryParse(prefixedCommand, out _outCommand, out _outParams);
                    Assert.IsTrue(result);
                }
            }

            [TestMethod]
            public void CommandsWithoutArgs_GetParsedCorrectly()
            {
                foreach (string command in _commands)
                {
                    string prefixedCommand = ParserPrefix + command;
                    bool result = _parser.TryParse(prefixedCommand, out _outCommand, out _outParams);
                    Assert.AreEqual(command, _outCommand, true);
                }
            }

            [TestMethod]
            public void CommandsWithOneArgument_ReturnTrue()
            {
                foreach (string command in _commands)
                {
                    string message = String.Join(ParserDelimiter,
                                                 ParserPrefix + command,
                                                 CommandArgument1);
                    bool result = _parser.TryParse(message, out _outCommand, out _outParams);
                    Assert.IsTrue(result);
                }
            }

            [TestMethod]
            public void CommandsWithOneArgument_GetParsedCorrectly()
            {
                foreach (string command in _commands)
                {
                    string message = String.Join(ParserDelimiter,
                                                 ParserPrefix + command,
                                                 CommandArgument1);
                    bool result = _parser.TryParse(message, out _outCommand, out _outParams);
                    Assert.AreEqual(1, _outParams.Count);
                    Assert.AreEqual(CommandArgument1, _outParams[0]);
                }
            }

            [TestMethod]
            public void CommandsWithManyArguments_GetParsedCorrectly()
            {
                foreach (string command in _commands)
                {
                    string message = String.Join(ParserDelimiter,
                                                 ParserPrefix + command,
                                                 CommandArgument1,
                                                 CommandArgument2);
                    bool result = _parser.TryParse(message, out _outCommand, out _outParams);
                    Assert.AreEqual(2, _outParams.Count);
                    Assert.AreEqual(CommandArgument1, _outParams[0]);
                    Assert.AreEqual(CommandArgument2, _outParams[1]);
                }
            }

            [TestMethod]
            public void CommandsWithManyArguments_EverythingGetsParsedCorrectly()
            {
                foreach (string command in _commands)
                {
                    string message = String.Join(ParserDelimiter,
                                                 ParserPrefix + command,
                                                 CommandArgument1,
                                                 CommandArgument2,
                                                 "");
                    bool result = _parser.TryParse(message, out _outCommand, out _outParams);
                    Assert.AreEqual(3, _outParams.Count);
                    Assert.AreEqual(command, _outCommand, true);
                    Assert.AreEqual(CommandArgument1, _outParams[0]);
                    Assert.AreEqual(CommandArgument2, _outParams[1]);
                    Assert.AreEqual("", _outParams[2]);
                }
            }
        }
    }
}
