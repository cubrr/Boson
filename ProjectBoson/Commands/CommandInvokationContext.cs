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
using InfinityScript;
using ProjectBoson;

namespace ProjectBoson.Commands
{
    public sealed class CommandInvokationContext
    {
        public BaseScript BaseScript { get; private set; }
        public BosonEntity Caller { get; private set; }
        public BaseScript.ChatType ChatType { get; private set; }
        public string Message { get; private set; }

        public CommandInvokationContext(BaseScript baseScript, BosonEntity caller, BaseScript.ChatType chatType, string message)
        {
            this.BaseScript = baseScript;
            Caller = caller;
            this.ChatType = chatType;
            Message = message;
        }
    }
}

