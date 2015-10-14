using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boson.Commands
{
    /// <summary>
    /// Provides a mechanism for parsing command names and parameters from a chat message.
    /// </summary>
    public interface ICommandParser
    {
        bool TryParse(string message, out string command, out IList<string> arguments);
    }
}
