using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boson.Api;
using InfinityScript;

namespace Boson.Commands.Default
{
    public class PmCommand : CommandBase
    {
        public override string Description
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string Name
        {
            get { return "pm"; }
        }

        public override string Usage
        {
            get
            {
                return "pm(source, target)";
            }
        }

        public override BaseScript.EventEat Invoke(IList<string> commandParams, CommandMessage context)
        {
            throw new NotImplementedException();
        }
    }
}
