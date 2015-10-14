using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using InfinityScript;

namespace Boson.Commands
{
    internal class ReflectionCommandProvider : ICommandProvider
    {
        private static readonly Func<Type, bool> CommandTypeFilter =
            t => typeof(ICommand).IsAssignableFrom(t)
                 && !t.IsAbstract
                 && !t.IsInterface
                 && !t.IsGenericType;

        private readonly Assembly[] _sourceAssemblies;

        public ReflectionCommandProvider(params Assembly[] sourceAssemblies)
        {
            _sourceAssemblies = sourceAssemblies;
        }

        public IDictionary<string, ICommand> GetCommands()
        {
            var commands = new Dictionary<string, ICommand>();
            int exceptionCount = 0;

            foreach (Type t in _sourceAssemblies.SelectMany(GetAssemblyCommands))
            {
                try
                {
                    var commandInstance = (ICommand)Activator.CreateInstance(t);
                    commands[commandInstance.Name] = commandInstance;

                    foreach (string alias in commandInstance.Aliases)
                    {
                        if (commands.ContainsKey(alias))
                        {
                            Log.Error("WARNING: Existing command \"{0}\" overwritten by identical alias of command \"{1}\"!",
                                      alias, commandInstance.Name);
                        }
                        commands[alias] = commandInstance;
                    }
                }
                catch (Exception ex)
                {
                    if (exceptionCount > 5)
                    {
                        Log.Error("Exceeded the limit of {0} exceptions while creating command instances! Aborting.",
                                  exceptionCount);
                        break;
                    }
                    ++exceptionCount;
                    Log.Error("Exception while creating instance of command [{0}]: {1}", t, ex);
                }
            }

            return commands;
        }

        private static IEnumerable<Type> GetAssemblyCommands(Assembly assembly)
        {
            Log.Info("Loading commands from assembly: " + assembly);

            try
            {
                var types = assembly.GetTypes();
                return types.Where(CommandTypeFilter);
            }
            catch (ReflectionTypeLoadException ex)
            {
                Log.Error("Exception while loading command types from assembly! " + ex.ToString());
                return new Type[0];
            }
        }
    }
}
