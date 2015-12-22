using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boson.Api.Messaging;
using InfinityScript;

namespace Boson.Messaging
{
    public class DefaultServerMessenger : IServerMessenger
    {
        public void SendConsoleMessage(Entity entity, string message)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(Entity entity, string message, bool sendConsoleMessage = true)
        {
            throw new NotImplementedException();
        }

        public void SendMessageToAll(string message, bool sendConsoleMessage = true)
        {
            throw new NotImplementedException();
        }
    }
}
