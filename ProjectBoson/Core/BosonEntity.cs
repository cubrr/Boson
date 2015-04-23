using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityScript;
using ProjectBoson.Core;

namespace ProjectBoson.Core
{
    public class BosonEntity
    {
        public Entity BaseEntity { get; private set; }
        public Callsign Callsign { get; private set; }
        public int ClientId { get { return BaseEntity.EntRef; } }
        public HwidIdentifier Hwid { get; private set; }
        public string Username { get; private set; }

        //public IRank Rank { get; set; }
        //public Account Account { get; set; }

        public BosonEntity(Entity entity)
        {
            BaseEntity = entity;
            Username = entity.Name;
            Callsign = new Callsign(entity);
        }
    }
}
