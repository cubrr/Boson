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

namespace Boson.Commands.Default
{
    public class PmCommand : CommandBase
    {
        public override IEnumerable<string> Aliases
        {
            get
            {
                yield return "m";
            }
        }

        public override string Description => "Sends a private message to another user.";

        public override string Name => "pm";

        // TODO: Figure out a character for prefixing the slot ID, ideally one that can't be used in usernames
        public override string Usage => "pm [slot#|recipient] [message]";

        public override BaseScript.EventEat Invoke(IList<string> commandArgs, CommandInvokationContext context)
        {
            if (commandArgs.Count < 2)
            {
                Utilities.RawSayTo(context.Caller, Usage);
            }

            // TODO: Slot id handling

            // pls no breach of trust by other plugins
            return BaseScript.EventEat.EatScript;
        }
    }
}
