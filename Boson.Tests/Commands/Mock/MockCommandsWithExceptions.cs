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
using Boson.Commands;
using InfinityScript;
using Boson.Api;
using Boson.Api.Commands;

namespace Boson.Tests.Commands.Mock
{
    public class MockCommandsWithExceptions
    {
        public class ThrowConstructorCommand1 : CommandBase
        {
            public ThrowConstructorCommand1()
            {
                throw new Exception("ThrowConstructorCommand1");
            }

            public override string Name
            {
                get { return "ThrowConstructorCommand1"; }
            }

            public override BaseScript.EventEat Invoke(IList<string> commandParams, OnSayParameters context)
            {
                throw new NotImplementedException();
            }

            public override void PrintHelp(IList<string> commandParams, OnSayParameters context)
            {
                throw new NotImplementedException();
            }
        }

        public class ThrowConstructorCommand2 : CommandBase
        {
            public ThrowConstructorCommand2()
            {
                throw new Exception("ThrowConstructorCommand2");
            }

            public override string Name
            {
                get { return "ThrowConstructorCommand2"; }
            }

            public override BaseScript.EventEat Invoke(IList<string> commandParams, OnSayParameters context)
            {
                throw new NotImplementedException();
            }

            public override void PrintHelp(IList<string> commandParams, OnSayParameters context)
            {
                throw new NotImplementedException();
            }
        }

        public class ThrowStaticConstructorCommand3 : CommandBase
        {
            static ThrowStaticConstructorCommand3()
            {
                throw new Exception("ThrowStaticConstructorCommand3");
            }

            public override string Name
            {
                get { return "ThrowConstructorCommand2"; }
            }

            public override BaseScript.EventEat Invoke(IList<string> commandParams, OnSayParameters context)
            {
                throw new NotImplementedException();
            }

            public override void PrintHelp(IList<string> commandParams, OnSayParameters context)
            {
                throw new NotImplementedException();
            }
        }

        public class ThrowConstructorCommand4 : CommandBase
        {
            public ThrowConstructorCommand4()
            {
                throw new Exception("ThrowConstructorCommand4");
            }

            public override string Name
            {
                get { return "ThrowConstructorCommand4"; }
            }

            public override BaseScript.EventEat Invoke(IList<string> commandParams, OnSayParameters context)
            {
                throw new NotImplementedException();
            }

            public override void PrintHelp(IList<string> commandParams, OnSayParameters context)
            {
                throw new NotImplementedException();
            }
        }

        public class ThrowConstructorCommand5 : CommandBase
        {
            public ThrowConstructorCommand5()
            {
                throw new Exception("ThrowConstructorCommand5");
            }

            public override string Name
            {
                get { return "ThrowConstructorCommand5"; }
            }

            public override BaseScript.EventEat Invoke(IList<string> commandParams, OnSayParameters context)
            {
                throw new NotImplementedException();
            }

            public override void PrintHelp(IList<string> commandParams, OnSayParameters context)
            {
                throw new NotImplementedException();
            }
        }

        public class ThrowConstructorCommand6 : CommandBase
        {
            public ThrowConstructorCommand6()
            {
                throw new Exception("ThrowConstructorCommand6");
            }

            public override string Name
            {
                get { return "ThrowConstructorCommand6"; }
            }

            public override BaseScript.EventEat Invoke(IList<string> commandParams, OnSayParameters context)
            {
                throw new NotImplementedException();
            }

            public override void PrintHelp(IList<string> commandParams, OnSayParameters context)
            {
                throw new NotImplementedException();
            }
        }
    }
}
