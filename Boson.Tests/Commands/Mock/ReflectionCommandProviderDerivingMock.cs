using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boson.Commands;

namespace Boson.Tests.Commands.Mock
{
    public class ReflectionCommandProviderDerivingMock
        : ReflectionCommandProvider
    {
        /// <summary>
        /// Tests the protected constructor
        /// </summary>
        public ReflectionCommandProviderDerivingMock()
            : base()
        {
        }
    }
}
