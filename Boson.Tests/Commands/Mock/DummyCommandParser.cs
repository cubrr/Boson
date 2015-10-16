using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boson.Commands;

namespace Boson.Tests.Commands.Mock
{
    public class DummyCommandParser : ICommandParser
    {
        private readonly bool _returnValue;

        public DummyCommandParser(bool returnValue)
        {
            _returnValue = returnValue;
        }

        public bool TryParse(string message, out string command, out IList<string> arguments)
        {
            command = null;
            arguments = null;
            return _returnValue;
        }
    }
}
