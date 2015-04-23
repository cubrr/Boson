using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBoson.Commands
{
    public abstract class Command
    {
        public string Name { get; private set; }
        public List<string> Aliases { get; private set; }
    }
}
