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
            Commands = new Dictionary<string, ICommand>();
            _sourceAssemblies = sourceAssemblies;
        }


        public IDictionary<string, ICommand> Commands { get; private set; }


        public void LoadCommands()
        {
            int exceptionCount = 0;
            foreach (Type t in _sourceAssemblies.SelectMany(GetAssemblyCommands))
            {
                try
                {
                    var commandInstance = (ICommand)Activator.CreateInstance(t);
                    Commands[commandInstance.Name] = commandInstance;

                    foreach (string alias in commandInstance.Aliases)
                    {
                        if (Commands.ContainsKey(alias))
                        {
                            Log.Error("WARNING: Existing command \"{0}\" overwritten by identical alias of command \"{1}\"!",
                                      alias, commandInstance.Name);
                        }
                        Commands[alias] = commandInstance;
                    }
                }
                catch (Exception ex)
                {
                    if (exceptionCount > 5)
                    {
                        Log.Error("Exceeded {0} exceptions while creating command instances! Aborting.",
                                  exceptionCount);
                        return;
                    }
                    ++exceptionCount;
                    Log.Error("Exception while creating instance of command [{0}]: {1}", t, ex);
                }
            }
        }

        private IEnumerable<Type> GetAssemblyCommands(Assembly assembly)
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
