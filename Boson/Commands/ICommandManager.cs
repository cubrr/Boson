using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boson.Commands
{
    public interface ICommandManager
    {
        void Invoke(string commandName, IList<string> commandParams, OnSayParameters onSayParams);
    }
}
