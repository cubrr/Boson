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

        public BosonEntity(Entity entity)
        {
            BaseEntity = entity;
			Callsign = new Callsign(NativeGateway.GetClantag(entity), NativeGateway.GetTitle(entity));
			ClientId = entity.EntRef;
			Hwid = new HwidIdentifier(NativeGateway.GetHwid(entity));
			Username = entity.Name;
        }

		#region IEquatable implementation

		public bool Equals(BosonEntity other)
		{
			return 	BaseEntity.Equals(other.BaseEntity) &&
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
