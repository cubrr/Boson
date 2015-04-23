using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectBoson.Helpers
{
    public static class Conversion
    {
        public static string ToHex(this byte[] array)
        {
            var sb = new StringBuilder();
            foreach (byte b in array)
            {
                sb.AppendFormat("{0:X2}", b);
            }
            return sb.ToString();
        }
    }
}
