using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boson.Commands;

namespace Boson.Tests.Commands.Mock
{
    public class SimpleCommandParserDerivingMock
        : SimpleCommandParser
    {
        /// <summary>
        /// Tests the protected constructor of SimpleCommandParser
        /// </summary>
        public SimpleCommandParserDerivingMock()
            : base()
        {
        }
    }
}
