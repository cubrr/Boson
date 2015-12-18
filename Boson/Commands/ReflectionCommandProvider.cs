// This file is a part of Boson - an administrative plugin for TeknoMW3
// Copyright © 2015 cubrr (jay@thecuber.org)
// Uses InfinityScript, Copyright © 2012 NTA
//
// Boson is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Boson is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Boson.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using InfinityScript;
using Boson.Api;
using Boson.Api.Commands;

namespace Boson.Commands
{
    /// <summary>
    /// Loads and provides commands from assemblies with reflection.
    /// Command names are converted to lower case.
    /// </summary>
    public class ReflectionProvider : ICommandProvider
    {
        private readonly IEnumerable<Assembly> _sourceAssemblies;

        protected ReflectionProvider()
        {
        }

        public ReflectionProvider(params Assembly[] sourceAssemblies)
        {
            if (sourceAssemblies == null
                || sourceAssemblies.Length == 0
                || sourceAssemblies.Any(a => a == null))
            {
                throw new ArgumentNullException("sourceAssemblies", "Null assemblies are not allowed.");
            }

            List<Assembly> distinctAssemblies = sourceAssemblies.Distinct().ToList();
            int removedDuplicates = sourceAssemblies.Length - distinctAssemblies.Count;

            if (removedDuplicates > 0)
            {
                string assemblyWord = removedDuplicates == 1 ? "assembly" : "assemblies";
                Log.Write(LogLevel.Warning,
                          "Filtered out " + removedDuplicates + " duplicate " + assemblyWord + "!");
            }

            _sourceAssemblies = distinctAssemblies;
        }

        /// <summary>
        /// Predicate used to find compatible, ICommand-implementing
        /// classes.
        /// </summary>
        protected virtual Func<Type, bool> CommandTypeFilter
        {
            get
            {
                return t => typeof(ICommand).IsAssignableFrom(t)
                            && !t.IsAbstract
                            && !t.IsInterface
                            && !t.IsGenericType;
            }
        }

        /// <summary>
        /// Maximum amount of exceptions that can be thrown while
        /// constructing commands from an assembly before cancelling
        /// further command construction from that assembly.
        /// </summary>
        protected virtual int MaxCommandAssemblyExceptions
        {
            get { return 3; }
        }

        public IDictionary<string, ICommand> GetCommands()
        {
            var dictionary = new Dictionary<string, ICommand>();
            foreach (Assembly assembly in _sourceAssemblies)
            {
                ConstructCommands(dictionary, assembly);
            }
            return dictionary;
        }

        private void ConstructCommands(IDictionary<string, ICommand> targetDictionary, Assembly assembly)
        {
            int exceptionCount = 0;

            foreach (Type type in GetAssemblyCommands(assembly))
            {
                try
                {
                    var commandInstance = (ICommand)Activator.CreateInstance(type);
                    AddCommand(targetDictionary, commandInstance.Name, commandInstance);
                    foreach (string alias in commandInstance.Aliases)
                    {
                        AddCommand(targetDictionary, alias, commandInstance);
                    }
                }
                catch (Exception ex)
                {
                    if (exceptionCount >= MaxCommandAssemblyExceptions)
                    {
                        Log.Error("Exceeded the limit of {0} exceptions while creating command "
                                  + "instances! Cancelling further command discovery from assembly.",
                                  MaxCommandAssemblyExceptions);
                        break;
                    }
                    ++exceptionCount;
                    Log.Error("Exception while creating instance of command [{0}]! Exception: {1}", type, ex);
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
                Log.Error("Exception while loading command types from assembly! " + ex);
                return new Type[0];
            }
        }

        private void AddCommand(IDictionary<string, ICommand> dict, string key, ICommand command)
        {
            key = key.ToLower();
            ICommand existingInstance;

            if (dict.TryGetValue(key, out existingInstance))
            {
                Log.Write(LogLevel.Warning,
                          "Existing command {0} [{1}] overwritten by "
                          + "identically named or aliased [{2}]!",
                          key, existingInstance.GetType(), command.GetType());
            }
            dict[key] = command;
        }
    }
}
