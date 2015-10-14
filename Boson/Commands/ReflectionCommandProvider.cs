// Boson - TeknoMW3 Administrative Plugin
// Copyright © 2015 cubrr (jay@thecuber.org)
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

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
                Log.Error("Exception while loading command types from assembly! " + ex);
                return new Type[0];
            }
        }
    }
}
