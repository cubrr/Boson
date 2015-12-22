using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;
using Boson.Api.Commands;
using Boson.Api.Messaging;

namespace Boson.Api
{
    // Can't mandate BaseScript inheritance in an interface :(
    public abstract class BosonAdminBase : BaseScript
    {
        public abstract ICommandRepository CommandRepository { get; protected set; }

        public abstract IServerMessenger ServerMessenger { get; protected set; }
    }
}
