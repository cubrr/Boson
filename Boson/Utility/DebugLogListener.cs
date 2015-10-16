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
using System.Diagnostics;
using System.Linq;
using System.Text;
using InfinityScript;

namespace Boson.Utility
{
    public class DebugLogListener : ILogListener
    {
        public void LogMessage(string source, string message, LogLevel level)
        {
            string formattedMessage = String.Format("[{0}][{1}]:\r\n    {2}", source, level, message);
            Debug.WriteLine(formattedMessage);
#if (!DEBUG)
            Utilities.RawSayAll(formattedMessage);
#endif
        }

        public bool WantsFilteredMessages
        {
            get { return true; }
        }
    }
}
