using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;

namespace Boson.Api.Messaging
{
    /// <summary>
    /// Provides a mechanism for sending messages as the server.
    /// </summary>
    public interface IServerMessenger
    {
        /// <summary>
        /// Sends a message from the server to the specified entity.
        /// </summary>
        /// <param name="entity">The recipient entity.</param>
        /// <param name="message">The message.</param>
        /// <param name="sendConsoleMessage">
        /// Specifies whether the message should also be sent to the player's
        /// console.
        /// </param>
        void SendMessage(Entity entity, string message, bool sendConsoleMessage = true);

        /// <summary>
        /// Sends a message from the server to the specified entity's console.
        /// </summary>
        /// <param name="entity">The recipient entity.</param>
        /// <param name="message">The message.</param>
        void SendConsoleMessage(Entity entity, string message);

        /// <summary>
        /// Sends a message from the server to all players.
        /// </summary>
        /// <param name="message">The message.</param>
        void SendMessageToAll(string message, bool sendConsoleMessage = true);
    }
}
