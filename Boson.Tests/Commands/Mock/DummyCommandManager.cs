using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boson.Commands;
using InfinityScript;

namespace Boson.Tests.Commands.Mock
{
    public class DummyCommandManager : ICommandManager
    {
        private readonly BaseScript.EventEat _returnValue;

        public DummyCommandManager(BaseScript.EventEat returnValue)
        {
            _returnValue = returnValue;
        }

        public BaseScript.EventEat Invoke(string commandName, IList<string> commandParams, OnSayParameters onSayParams)
        {
            return _returnValue;
        }
    }
}
