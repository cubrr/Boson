using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boson.Api.Messaging;
using InfinityScript;

namespace Boson.Messaging
{
    public class DefaultPlayerMessenger : IPlayerMessenger
    {
        public void SendPrivateMessage(Entity sender, Entity recipient, string message)
        {
            // TODO: Colors and customizable clan name instead of [Boson]?
            // PM -> cubrr: "Step up your game, skrub"
            Utilities.RawSayTo(sender, String.Format(@"[Boson] PM -> {0}: ""{1}""", recipient.Name, message));
            // cubrr: Step up your game, skrub
            Utilities.RawSayTo(recipient, String.Format("[Boson] {0}: {1}", sender.Name, message));
        }
    }
}
