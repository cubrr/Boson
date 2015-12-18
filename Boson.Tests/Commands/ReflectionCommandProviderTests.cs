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
using System.Text;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boson.Commands;
using Boson.Tests.Commands.Mock;
using InfinityScript;
using Boson.Api;
using Boson.Api.Commands;
// ReSharper disable All

namespace Boson.Tests.Commands
{
    [TestClass]
    public class ReflectionCommandProviderTests
    {

        [TestClass]
        public class Constructors
        {
            private TestLogListener _logListener;

            public Constructors()
            {
                _logListener = new TestLogListener();
                Log.Initialize(LogLevel.All);
                Log.AddListener(_logListener);
            }

            [TestMethod]
            public void ParameterlessConstructor_NoException()
            {
                new ReflectionCommandProviderDerivingMock();
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void SoloNullAssemblyArgument_ThrowsException()
            {
                new ReflectionCommandProvider(null);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void NullAssemblyArgument_ThrowsException()
            {
                new ReflectionCommandProvider(Assembly.GetExecutingAssembly(), null);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void EmptyAssemblyListArgument_ThrowsException()
            {
                new ReflectionCommandProvider(new Assembly[10]);
            }

            [TestMethod]
            public void DuplicateAssemblies_WritesLogWarning()
            {
                var assembly = Assembly.GetExecutingAssembly();
                new ReflectionCommandProvider(assembly, assembly);

                string typeName = typeof(ReflectionCommandProvider).Name;
                var m = _logListener.Messages.Last();
                bool logMessageFound = m.LogLevel == LogLevel.Warning
                                       && m.Source == typeName + "::" + typeName
                                       && m.Message.Contains("duplicate");
                Assert.IsTrue(logMessageFound);
            }
        }

        [TestClass]
        public class GetCommandsMethod
        {
            private TestLogListener _logListener;

            private ReflectionCommandProvider _provider;

            public GetCommandsMethod()
            {
                _logListener = new TestLogListener();
                Log.Initialize(LogLevel.All);
                Log.AddListener(_logListener);
                _provider = new ReflectionCommandProvider(Assembly.GetExecutingAssembly());
            }

            [TestMethod]
            public void ReceivedCommandDictionry_NotNull()
            {
                IDictionary<string, ICommand> cmds =_provider.GetCommands();
                Assert.IsNotNull(cmds);
            }

            [TestMethod]
            public void ReceivedCommandDictionryValues_NotNull()
            {
                IDictionary<string, ICommand> cmds = _provider.GetCommands();
                Assert.IsFalse(cmds.Any(pair => pair.Value == null));
            }

            [TestMethod]
            public void ReceivedCommandDictinaryCommandNames_NotNullOrEmpty()
            {
                IDictionary<string, ICommand> cmds = _provider.GetCommands();
                Assert.IsFalse(cmds.Any(pair => pair.Value == null));
            }
        }
    }
}
