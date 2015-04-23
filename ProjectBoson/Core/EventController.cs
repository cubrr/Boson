using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityScript;

namespace ProjectBoson.Core
{
    public class EventController
    {
        private readonly Boson _bosonInstance;

        protected EventController() {}
        public EventController(Boson boson)
        {
            _bosonInstance = boson;
        }

        public void Boson_PlayerConnecting(Entity obj)
        {
            
        }

        public void Boson_PlayerConnected(Entity obj)
        {
            
        }

        public void Boson_PlayerDisconnected(Entity obj)
        {
            
        }

        public BaseScript.EventEat Boson_OnSay3(Entity player, BaseScript.ChatType chatType, string name, ref string message)
        {
            return BaseScript.EventEat.EatNone;
        }
    }
}
