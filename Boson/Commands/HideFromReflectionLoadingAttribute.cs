using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boson.Commands
{
    /// <summary>
    /// Indicates that the class should not be loaded when reflection is used
    /// to load commands from an assembly.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    public sealed class HideFromReflectionLoadingAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HideFromReflectionLoadingAttribute"/> class.
        /// </summary>
        public HideFromReflectionLoadingAttribute()
        {
        }
    }
}
