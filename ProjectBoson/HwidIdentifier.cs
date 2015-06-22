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

namespace ProjectBoson
{
    /// <summary>
    /// Represents a 12-byte HWID.
    /// </summary>
    /// <remarks>The memory region from which the identifier is taken from used to be where the player's HWID was, but nowadays doesn't match the HWID produced into the native banlist.</remarks>
    public struct HwidIdentifier : IEquatable<HwidIdentifier>
    {
        /// <summary>
        /// String representation of the 12-byte ID.
        /// </summary>
        public readonly string Identifier;

        /// <summary>
        /// Initializes a new instance of the BosonIdentifier class with the specified ID.
        /// </summary>
        /// <param name="hwid"></param>
        public HwidIdentifier(string hwid)
        {
            Identifier = hwid;
        }

        #region IEquatable interface implementation

        public bool Equals(HwidIdentifier other)
        {
            return String.Equals(Identifier, other.Identifier, StringComparison.OrdinalIgnoreCase);
        }

        #endregion

        #region Object overloads

        public override bool Equals(object obj)
        {
            return obj is HwidIdentifier &&
                   this == (HwidIdentifier)obj;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int x = 15485807 + Identifier.GetHashCode();
                return x * 49724659;
            }
        }

        public override string ToString()
        {
            return Identifier;
        }

        #endregion

        #region Operators

        public static bool operator ==(HwidIdentifier left, HwidIdentifier right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(HwidIdentifier left, HwidIdentifier right)
        {
            return !(left == right);
        }

        #endregion
    }
}
