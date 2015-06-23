// Copyright (c) 2015 Joona Heikkilä
//
// This file is part of Boson.
// 
// Boson is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Boson is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Foobar.  If not, see <http://www.gnu.org/licenses/>.

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
            
            var chatMessage = new ChatMessage(message, chatType);

            string commandName;
            if (_commandManager.TryGetCommandName(chatMessage, out commandName))
            {
                //var context = new CommandInvokationContext(_bosonInstance,)
                //_commandManager.InvokeCommand(commandName, );
            }
            
            return BaseScript.EventEat.EatNone;
        }
    }
}
