using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boson.Commands
{
    /// <summary>
    /// Command parser for bang-prefixed commands with space delimited parameters.
    /// </summary>
    internal class BangCommandParser : SimpleCommandParser
    {
        public BangCommandParser()
            : base(commandPrefix: "!", tokenDelimiter: " ")
        {
            // Why do I use named parameters above? So that you don't 
            // even need to look at SimpleCommandParser to know what's up.
        }
    }
}
