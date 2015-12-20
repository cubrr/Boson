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
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Boson. If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boson.Api;
using Boson.Api.Commands;
using InfinityScript;

namespace Boson.Tests.Commands.Mock
{
    /// <summary>
    /// Dummy command for testing command provider implementations.
    /// </summary>
    /// <seealso cref="Boson.Api.Commands.ICommand" />
    /// <seealso cref="Boson.Api.Commands.ICommandProvider" />
    public class DummyCommand : ICommand
    {
        public IEnumerable<string> Aliases
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Usage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public BaseScript.EventEat Invoke(IList<string> commandParams, CommandMessage context)
        {
            throw new NotImplementedException();
        }
    }
}
