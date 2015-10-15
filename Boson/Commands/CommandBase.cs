using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boson.Commands
{
    public abstract class CommandBase : ICommand
    {
        private readonly static string[] EmptyAliasList = new string[0];

        public abstract string Name { get; }

        public virtual IEnumerable<string> Aliases
        {
            get { return EmptyAliasList; }
        }

        public abstract void Invoke(IList<string> commandParams, OnSayParameters context);

        public abstract void PrintHelp(IList<string> commandParams, OnSayParameters context);
    }
}
