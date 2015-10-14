using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using InfinityScript;

namespace Boson.Commands
{
    internal class CommandManager : ICommandManager
    {
        private readonly IDictionary<string, ICommand> _commands;

        public CommandManager(ICommandProvider provider)
        {
            _commands = provider.GetCommands();
        }

        public void Invoke(string commandName, IList<string> commandParams, OnSayParameters onSayParams)
        {
            ICommand command;
            if (!_commands.TryGetValue(commandName, out command))
            {
                // TODO: 
                Utilities.RawSayTo(onSayParams.Caller, "Command " + commandName + " not recognized!");
            }
        }
    }

    internal interface ICommandManager
    {
        void Invoke(string commandName, IList<string> commandParams, OnSayParameters onSayParams);
    }
}
