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
using Boson.Api;
using Boson.Api.Commands;
using InfinityScript;

namespace Boson.Commands
{
    /// <summary>
    ///     Loads and provides commands from assemblies with reflection.
    ///     Command names are converted to lower case.
    /// </summary>
    public class ReflectionCommandProvider : ICommandProvider
    {
        private readonly IEnumerable<Assembly> _sourceAssemblies;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReflectionCommandProvider"/> class
        ///     and specifies a list of source assemblies to search for commands.
        /// </summary>
        /// <param name="sourceAssemblies">
        ///     List of source assemblies to search for commands.
        /// </param>
        /// <remarks>
        ///     <note type="note">
        ///         The specified assemblies are not scanned until <see cref="GetCommands"/>
        ///         is called.
        ///     </note>
        /// </remarks>
        public ReflectionCommandProvider(params Assembly[] sourceAssemblies)
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
                          "Filtered out {0} duplicate {1}!",
                          removedDuplicates,
                          assemblyWord);
            }

            _sourceAssemblies = distinctAssemblies;
        }

        /// <summary>
        ///     Initializes a new instance of the ReflectionCommandProvider class
        ///     without specifying a list of source assemblies to search for commands.
        /// </summary>
        protected ReflectionCommandProvider()
        {
        }

        /// <summary>
        ///     Gets the predicate used to identify ICommands types.
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
        ///     Gets the maximum amount of exceptions that can be thrown while
        ///     constructing commands from an assembly before cancelling
        ///     further command construction from that assembly.
        /// </summary>
        protected virtual int MaxCommandAssemblyExceptions
        {
            get { return 3; }
        }

        /// <summary>
        ///     Scans the source assemblies for commands and returns a
        ///     dictionary where the key is the command's name and the
        ///     value is the ICommand itself.
        /// </summary>
        /// <returns>
        ///     An <see cref="IEnumerable{ICommand}"/> containing constructed
        ///     command instances from the source assemblies.
        /// </returns>
        public IEnumerable<ICommand> GetCommands()
        {
            var commands = new List<ICommand>();
            foreach (Assembly assembly in _sourceAssemblies)
            {
                FindAndConstructCommands(commands, assembly);
            }

            return commands;
        }

        private void FindAndConstructCommands(IList<ICommand> list, Assembly assembly)
        {
            if (list == null)
            {
                throw new ArgumentNullException("targetDictionary", "Someone really fucked up this time!");
            }

            int exceptionCount = 0;
            foreach (Type type in GetAssemblyCommands(assembly))
            {
                try
                {
                    var commandInstance = (ICommand)Activator.CreateInstance(type);
                    list.Add(commandInstance);
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
    }
}
