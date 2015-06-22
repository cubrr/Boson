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

