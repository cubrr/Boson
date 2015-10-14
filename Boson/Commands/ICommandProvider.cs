using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boson.Commands
{
    internal interface ICommandProvider
    {
        IDictionary<string, ICommand> GetCommands();
    }
}
