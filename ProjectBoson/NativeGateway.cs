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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using InfinityScript;

namespace ProjectBoson
{
    public static class NativeGateway
    {
        /// <summary>
        /// Copies bytes from unmanaged memory pointed at by <paramref name="ptr"/>. The amount of copied bytes is specified by <paramref name="count"/>.
        /// </summary>
        /// <param name="ptr">Pointer to the unmanaged memory location from which memory is to be copied.</param>
        /// <param name="count">Amount of bytes to copy.</param>
        /// <returns>A new <see cref="byte"/>[] containing the copied bytes.</returns>
        private static byte[] CopyBytes(IntPtr ptr, int count)
        {
            if (count <= 0)
                throw new ArgumentException("Cannot copy less than 1 byte", "count");
            if (ptr == IntPtr.Zero)
                throw new ArgumentNullException("ptr", "IntPtr.Zero passed!");

            var buffer = new byte[count];
            Marshal.Copy(ptr, buffer, 0, count);
            return buffer;
        }

        /// <summary>
        /// Gets an encoded string representation of specified byte array.
        /// </summary>
        /// <param name="bytes">Byte array to encode.</param>
        /// <param name="trimNulls">If <see langword="true"/>, trailing null characters will be trimmed from the returned string.</param>
        /// <param name="encoding"><see cref="Encoding"/> with which the string will be encoded in. If <see langword="null"/>, <see cref="ApplicationSettings.Encoding"/> will be used.</param>
        /// <returns></returns>
        public static string GetEncodedString(byte[] bytes, bool trimNulls = true, Encoding encoding = null)
        {
            string ret = (encoding ?? ApplicationSettings.Encoding).GetString(bytes);
            return trimNulls ? ret.TrimEnd('\0') : ret;
        }

        /// <summary>
        /// Gets the callsign title of the provided <see cref="Entity"/>.
        /// </summary>
        /// <param name="entity">Entity whose callsign title will be returned.</param>
        /// <returns>A new byte[24] containing the entity's callsign title.</returns>
        public static byte[] GetTitle(Entity entity)
        {
            var titleAddress = new IntPtr(0x1AC5548 + (entity.EntRef * 0x38A4));
            return CopyBytes(titleAddress, 24);
        }

        /// <summary>
        /// Gets the clantag of the provided <see cref="Entity"/>.
        /// </summary>
        /// <param name="entity">Entity whose clantag will be returned.</param>
        /// <returns>A new byte[7] containing the entity's clantag.</returns>
        public static byte[] GetClantag(Entity entity)
        {
            var tagAddress = new IntPtr(0x1AC5564 + (entity.EntRef * 0x38A4));
            return CopyBytes(tagAddress, 7);
        }

        public static string GetHwid(Entity entity)
        {
            var hwidAddress = new IntPtr((0x49EB690 + (entity.EntRef * 0x78688) + 0x44CA5));
            var bytes = CopyBytes(hwidAddress, 12);

            var sb = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                sb.AppendFormat("{0:X8}", BitConverter.ToUInt32(bytes, i * 4) ^ 0xDEADDEAD);
            }
            return sb.ToString();
        }
    }
}
