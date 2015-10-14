using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityScript;

namespace Boson
{
    internal struct OnSayParameters
    {
        public Entity Caller { get; private set; }

        public BaseScript.ChatType ChatType { get; private set; }

        public ICollection<string> Arguments { get; private set; }

        public OnSayParameters(Entity caller, BaseScript.ChatType chatType, ICollection<string> args)
            : this()
        {
            Caller = caller;
            ChatType = chatType;
            Arguments = args;
        }
    }
}
