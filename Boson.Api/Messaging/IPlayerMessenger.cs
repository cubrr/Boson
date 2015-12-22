using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;

namespace Boson.Api.Messaging
{
    /// <summary>
    /// Provides a mechanism for player-to-player messaging.
    /// </summary>
    public interface IPlayerMessenger
    {
        void SendPrivateMessage(Entity sender, Entity recipient, string message);
    }
}
