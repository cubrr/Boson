using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boson.Api;
using Boson.Api.Commands;
using InfinityScript;

namespace Boson.Tests.Commands.Mock
{
    /// <summary>
    /// Dummy command for testing command provider implementations.
    /// </summary>
    /// <seealso cref="Boson.Api.Commands.ICommand" />
    /// <seealso cref="Boson.Api.Commands.ICommandProvider" />
    public class DummyCommand : ICommand
    {
        public IEnumerable<string> Aliases
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Usage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public BaseScript.EventEat Invoke(IList<string> commandParams, CommandMessage context)
        {
            throw new NotImplementedException();
        }
    }
}
