using System;
using System.Collections.Generic;
using InfinityScript;

namespace ProjectBoson
{
    public class EntityController
    {
        private readonly Dictionary<Entity, BosonEntity> _entityMap;

        public EntityController()
        {
            _entityMap = new Dictionary<Entity, BosonEntity>();
        }
    }
}

