using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfinityScript;

namespace ProjectBoson
{
    /// <summary>
    /// Contains an entity's title and clantag.
    /// </summary>
	public struct Callsign : IEquatable<Callsign>
    {
        /// <summary>
        /// 7-byte long array containing the clantag.
        /// </summary>
        public byte[] Clantag { get; private set; }

        /// <summary>
        /// 24-byte long array containing the callsign title.
        /// </summary>
        public byte[] Title { get; private set; }

		// TODO: Find the offsets for the callsign background and emblem

        /// <summary>
        /// Initializes a new instance of the Callsign class
        /// </summary>
        /// <param name="clantag">Byte array containing the clantag.</param>
        /// <param name="title">Byte array containing the callsign title.</param>
        public Callsign(byte[] clantag, byte[] title)
        {
            Clantag = clantag;
            Title = title;
        }

        /// <summary>
        /// Gets a string representation of the clantag.
        /// </summary>
        /// <param name="trimNulls">If <see langword="true"/>, trailing null characters will be trimmed from the returned string.</param>
        /// <returns></returns>
        /// <remarks><note type="important">While the game client only saves 4 bytes of the clantag into file, a memory editor can be used to equip a 7-byte clantag into servers.</note></remarks>
        public string GetClantag(bool trimNulls = true)
        {
			return NativeGateway.GetEncodedString(Clantag, trimNulls);
        }

        /// <summary>
        /// Gets a string representation of the callsign title.
        /// </summary>
        /// <param name="trimNulls">If <see langword="true"/>, trailing null characters will be trimmed from the returned string.</param>
        /// <returns></returns>
        public string GetTitle(bool trimNulls = true)
        {
			return NativeGateway.GetEncodedString(Title, trimNulls);
        }

		#region IEquatable implementation

		public bool Equals(Callsign other)
		{
			return 	Clantag != null && // Gotta check all these nulls because otherwise SequenceEquals will throw
					Title != null &&
					other.Clantag != null &&
					other.Title != null &&
					Clantag.SequenceEqual(other.Clantag) &&
					Title.SequenceEqual(other.Clantag);
		}

		#endregion

		#region Object overloads

		public override bool Equals(object obj)
		{
			return obj is Callsign &&
				   Equals((Callsign)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 39916801;
				hash = hash * 479001599 + Title.GetHashCode();
				hash = hash * 479001599 + Clantag.GetHashCode();
				return hash;
			}
		}

		#endregion

		#region Operators

		public static bool operator ==(Callsign a, Callsign b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(Callsign a, Callsign b)
		{
			return !(a == b);
		}

		#endregion
    }
}
