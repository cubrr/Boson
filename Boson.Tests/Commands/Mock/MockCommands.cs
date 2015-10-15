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

namespace Boson.Tests.Commands.Mock
{
    public class KickCommand : CommandBase
    {
        public override string Name
        {
            get { return "kick"; }
        }

        public override IEnumerable<string> Aliases
        {
            get { yield return "k"; }
        }

        public override void Invoke(IList<string> commandParams, OnSayParameters context)
        {
            throw new NotImplementedException();
        }

        public override void PrintHelp(IList<string> commandParams, OnSayParameters context)
        {
            throw new NotImplementedException();
        }
    }

    public class SameAliasAsKickCommand : CommandBase
    {
        public override string Name
        {
            get { return "judokick"; }
        }

        public override IEnumerable<string> Aliases
        {
            get { yield return "kick"; }
        }

        public override void Invoke(IList<string> commandParams, OnSayParameters context)
        {
            throw new NotImplementedException();
        }

        public override void PrintHelp(IList<string> commandParams, OnSayParameters context)
        {
            throw new NotImplementedException();
        }
    }

    public class BanCommand : CommandBase
    {
        public override string Name
        {
            get { return "ban"; }
        }

        public override IEnumerable<string> Aliases
        {
            get { yield return "b"; }
        }

        public override void Invoke(IList<string> commandParams, OnSayParameters context)
        {
            throw new NotImplementedException();
        }

        public override void PrintHelp(IList<string> commandParams, OnSayParameters context)
        {
            throw new NotImplementedException();
        }
    }

    public class DebugCommand : CommandBase
    {
        public override string Name
        {
            get { return "debug"; }
        }

        public override void Invoke(IList<string> commandParams, OnSayParameters context)
        {
            throw new NotImplementedException();
        }

        public override void PrintHelp(IList<string> commandParams, OnSayParameters context)
        {
            throw new NotImplementedException();
        }
    }

    public class RandomCommand : CommandBase
    {
        public override string Name
        {
            get { return "random"; }
        }

        public override void Invoke(IList<string> commandParams, OnSayParameters context)
        {
            throw new NotImplementedException();
        }

        public override void PrintHelp(IList<string> commandParams, OnSayParameters context)
        {
            throw new NotImplementedException();
        }
    }

    public class LulzCommand : CommandBase
    {
        public override string Name
        {
            get { return "lulz"; }
        }

        public override void Invoke(IList<string> commandParams, OnSayParameters context)
        {
            throw new NotImplementedException();
        }

        public override void PrintHelp(IList<string> commandParams, OnSayParameters context)
        {
            throw new NotImplementedException();
        }
    }
}
