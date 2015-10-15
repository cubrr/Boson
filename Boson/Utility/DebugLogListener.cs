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
            Utilities.RawSayAll(formattedMessage);
        }

        public bool WantsFilteredMessages
        {
            get { return true; }
        }
    }
}
