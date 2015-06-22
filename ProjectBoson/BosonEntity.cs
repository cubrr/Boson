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
using ProjectBoson;

namespace ProjectBoson
{
    public class BosonEntity : IEquatable<BosonEntity>
    {
        public Entity BaseEntity { get; private set; }
        public Callsign Callsign { get; private set; }
        public int ClientId { get; private set; }
        public HwidIdentifier Hwid { get; private set; }
        public string Username { get; private set; }

        //public IRank Rank { get; set; }
        //public Account Account { get; set; }

        protected BosonEntity()
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectBoson.BosonEntity"/> class.
        /// </summary>
        /// <param name="entity">InfinityScript Entity.</param>
        /// <param name="callsign">The entity's callsign.</param>
        /// <param name="identifer">The entity's HWID.</param>
        public BosonEntity(Entity entity, Callsign callsign, HwidIdentifier identifer)
        {
            BaseEntity = entity;
            Callsign = callsign;
            ClientId = entity.EntRef;
            Hwid = identifer;
            Username = entity.Name;
        }

        #region IEquatable implementation

        public bool Equals(BosonEntity other)
        {
            return     BaseEntity.Equals(other.BaseEntity) &&
                    Callsign == other.Callsign &&
                    ClientId == other.ClientId &&
                    Hwid == other.Hwid &&
                    Username == other.Username;
        }

        #endregion

        #region Object overloads

        public override bool Equals(object obj)
        {
            var other = obj as BosonEntity;
            return other != null && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 25964951;
                hash = hash * 24036583 + BaseEntity.GetHashCode();
                hash = hash * 24036583 + Callsign.GetHashCode();
                hash = hash * 24036583 + ClientId.GetHashCode();
                hash = hash * 24036583 + Hwid.GetHashCode();
                hash = hash * 24036583 + Username.GetHashCode();
                return hash;
            }
        }

        #endregion
    }
}
