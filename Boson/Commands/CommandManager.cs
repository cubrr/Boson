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

        public void LoadCommands(Assembly assembly)
        {
            Log.Info("Loading commands from assembly: " + assembly);
            // TODO: Create separate ICommandProvider, this one's ReflectionCommandProvider
            IEnumerable<Type> types;
            try
            {
                types = assembly.GetTypes()
                    .Where(t => typeof(ICommand).IsAssignableFrom(t) &&
                                !t.IsAbstract &&
                                !t.IsInterface &&
                                !t.IsGenericType);
            }
            catch (ReflectionTypeLoadException ex)
            {
                Log.Error("Exception while loading command types from assembly! " + ex.ToString());
                return;
            }

            foreach (Type t in types)
            {
                try
                {
                    var instance = (ICommand)Activator.CreateInstance(t);
                    _commands[instance.Name] = instance;

                    foreach (string alias in instance.Aliases)
                    {

                    }
                }
                catch (Exception ex)
                {
                    Log.Error("Exception while creating instance of command [{0}]: {1}", t, ex);
                }
            }
        }
    }
}
