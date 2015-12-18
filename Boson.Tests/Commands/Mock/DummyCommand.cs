using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boson.Api;
using Boson.Api.Commands;
using InfinityScript;

namespace Boson.Tests.Commands.Mock
{
    public class DummyCommand : ICommand
    {

        public string Name
        {
            get { return ""; }
        }

        public IEnumerable<string> Aliases
        {
            get { return new string[0]; }
        }

        public BaseScript.EventEat Invoke(IList<string> commandParams, OnSayParameters context)
        {
            return BaseScript.EventEat.EatNone;
        }

        public void PrintHelp(IList<string> commandParams, OnSayParameters context)
        {
            
        }
    }
}
