using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using InfinityScript;

namespace Boson.Commands
{
    internal class CommandManager
    {
        private Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();
    }
}
