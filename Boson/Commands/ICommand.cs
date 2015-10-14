using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boson.Commands
{
    internal interface ICommand
    {
        string Name { get; }

        IEnumerable<string> Aliases { get; }

        void Invoke(OnSayParameters context);

        void PrintHelp(OnSayParameters context);
    }
}
