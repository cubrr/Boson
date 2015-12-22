using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boson.Api.Messaging;
using InfinityScript;

namespace Boson.Tests.Messaging.Mock
{
    public class DummyServerMessenger : IServerMessenger
    {
        public void SendConsoleMessage(Entity entity, string message)
        {
        }

        public void SendMessage(Entity entity, string message, bool sendConsoleMessage = true)
        {
        }

        public void SendMessageToAll(string message, bool sendConsoleMessage = true)
        {
        }
    }
}
