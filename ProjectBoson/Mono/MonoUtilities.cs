using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProjectBoson.Mono
{
    public static class MonoUtilities
    {
        /// <summary>
        /// Casts object <paramref name="obj"/> to type <typeparamref name="T"/>. If <paramref name="obj"/> cannot be cast or converted to <typeparamref name="T"/>, returns default(<typeparamref name="T"/>).
        /// </summary>
        /// <remarks>
        /// <note type="note">Original implementation by Bob: http://stackoverflow.com/a/899636/996081 </note>
        /// </remarks>
        private static T CastTo<T>(this object obj)
        {
            if (obj is T)
            {
                return (T) obj;
            }
            try
            {
                return (T)Convert.ChangeType(obj, typeof(T));
            }
            catch (InvalidCastException)
            {
                return default(T);
            }
        }
        private static T GetPropertyValue<T>(string typeName, string propertyName, BindingFlags flags)
        {
            Type type = Type.GetType(typeName);
            if (type == null)
                return default(T);

            PropertyInfo prop = type.GetProperty(propertyName, flags);
            if (prop == null)
                return default(T);

            object value = prop.GetValue(type, null);
            return value.CastTo<T>();
        }

        /// <summary>
        /// Gets the specified method's return value via reflection. Does not support parameters.
        /// </summary>
        private static T GetMethodValue<T>(string typeName, string methodName, BindingFlags flags)
        {
            Type type = Type.GetType(typeName);
            if (type == null)
                return default(T);

            MethodInfo method = type.GetMethod(methodName, flags);
            if (method == null)
                return default(T);

            object ret = method.Invoke(null, null);
            return ret.CastTo<T>();
        }

        public static string GetMonoVersion()
        {
            return GetMethodValue<string>("Mono.Runtime", "GetDisplayName", BindingFlags.NonPublic | BindingFlags.Static);
        }
    }
}
