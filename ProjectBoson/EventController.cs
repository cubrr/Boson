using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityScript;
using ProjectBoson.Commands;

namespace ProjectBoson
{
    public class EventController
    {
        private readonly Boson _bosonInstance;
		private readonly CommandManager _commandManager;

        protected EventController() {}
        public EventController(Boson boson, CommandManager commandManager)
        {
            _bosonInstance = boson;
			_commandManager = commandManager;
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
			if (String.IsNullOrWhiteSpace(message))
				return BaseScript.EventEat.EatNone;

			return BaseScript.EventEat.EatNone;
        }
    }
}
