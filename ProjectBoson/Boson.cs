using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using InfinityScript;
using ProjectBoson.Core;
using ProjectBoson.Models;
using ProjectBoson.Mono;

namespace ProjectBoson
{
    public class Boson : BaseScript
    {
        private readonly EventController _eventController;
        //private readonly BosonDb _database;

        public Boson()
        {
            Log.Info("Starting Boson.");
            Log.Info("Mono runtime version: " + MonoUtilities.GetMonoVersion());

            _eventController = new EventController(this);
            PlayerConnecting += _eventController.Boson_PlayerConnecting;
            PlayerConnected += _eventController.Boson_PlayerConnected;
            PlayerDisconnected += _eventController.Boson_PlayerDisconnected;

        }

        public override EventEat OnSay3(Entity player, ChatType type, string name, ref string message)
        {
            return _eventController.Boson_OnSay3(player, type, name, ref message);
        }
    }
}
