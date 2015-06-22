using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using InfinityScript;
using ProjectBoson;
using ProjectBoson.Models;
using ProjectBoson.Meta;
using ProjectBoson.Commands;

namespace ProjectBoson
{
    public class Boson : BaseScript
    {
        private readonly EventController _eventController;
        //private readonly BosonDb _database;

        public Boson()
        {
            Log.Info("Starting Boson.");
			#if DEBUG
			Log.Info(GetDebugInformation());
			#endif

			_eventController = new EventController(this, new CommandManager());
            PlayerConnecting += _eventController.Boson_PlayerConnecting;
            PlayerConnected += _eventController.Boson_PlayerConnected;
            PlayerDisconnected += _eventController.Boson_PlayerDisconnected;
        }

        public override EventEat OnSay3(Entity player, ChatType type, string name, ref string message)
        {
            return _eventController.Boson_OnSay3(player, type, name, ref message);
        }

		#if DEBUG
		private static string GetDebugInformation()
		{
			string ret = "Debug information\r\n-----------------" +
			             "Mono runtime version: " + MetaUtilities.GetMonoVersion() + "\r\n" +
						 "Assembly version: " + MetaUtilities.GetAssemblyVersion();
			return ret;
		}
		#endif
    }
}
