using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBoson.Core
{
    /// <summary>
    /// Contains an entity's title and clantag.
    /// </summary>
    public class Callsign
    {
        /// <summary>
        /// 7-byte long array containing the clantag.
        /// </summary>
        public byte[] Clantag { get; private set; }

        /// <summary>
        /// 24-byte long array containing the callsign title.
        /// </summary>
        public byte[] Title { get; private set; }

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
        /// Initializes a new instance of the Callsign class.
        /// </summary>
        /// <param name="entity"><see cref="InfinityScript.Entity"/> from which the callsign details will be obtained from.</param>
        public Callsign(InfinityScript.Entity entity)
            : this(NativeGateway.GetClantag(entity), NativeGateway.GetTitle(entity))
        {
        }

        /// <summary>
        /// Initializes a new instance of the Callsign class.
        /// </summary>
        /// <param name="entity"><see cref="BosonEntity"/> from which the callsign details will be obtained from.</param>
        public Callsign(BosonEntity entity)
            : this(entity.BaseEntity)
        {
        }

        /// <summary>
        /// Gets a string representation of the clantag.
        /// </summary>
        /// <param name="trimNulls">If <see langword="true"/>, trailing null characters will be trimmed from the returned string.</param>
        /// <returns></returns>
        /// <remarks><note type="important">While the game client only saves 4 bytes of the clantag into file, a memory editor can be used to equip a 7-byte clantag into servers.</note></remarks>
        public string GetClantag(bool trimNulls = true)
        {
            return NativeGateway.GetString(Clantag, trimNulls);
        }

        /// <summary>
        /// Gets a string representation of the callsign title.
        /// </summary>
        /// <param name="trimNulls">If <see langword="true"/>, trailing null characters will be trimmed from the returned string.</param>
        /// <returns></returns>
        public string GetTitle(bool trimNulls = true)
        {
            return NativeGateway.GetString(Title, trimNulls);
        }
    }
}
