using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boson.Api;
using Boson.Api.Commands;
using InfinityScript;

namespace Boson.Commands
{
    // See CommandRepository.cs for CommandRepository implementation
    public partial class CommandRepository : ICommandRepository
    {
        private class HelpCommand : CommandBase
        {
            private IDictionary<string, CommandRepositoryEntry> _commands;

            private IEnumerable<string> _commandNames;

            public override IEnumerable<string> Aliases
            {
                get
                {
                    yield return "h";
                    yield return "man";
                }
            }

            public override string Description => "Displays command usage help or a list of available commands.";

            public override string Name => "help";

            public override string Usage => "help [command name (optional)]";

            public HelpCommand(IDictionary<string, CommandRepositoryEntry> commands)
            {
                _commands = commands;
                _commandNames = _commands.Where(kp => !kp.Value.IsAlias)
                                         .Select(kp => kp.Key)
                                         .OrderBy(name => name, StringComparer.CurrentCultureIgnoreCase);
            }

            public override BaseScript.EventEat Invoke(IList<string> commandArgs, CommandInvokationContext context)
            {
                if (commandArgs.Count == 1 && !String.IsNullOrWhiteSpace(commandArgs[0]))
                {
                    // Q: What if the args count is 2 because a command name
                    //    contains whitespace?
                    // A: Use a token delimiter in the SimpleCommandParser
                    //    ctor that isn't whitespace, or create your own 
                    //    ICommandParser class. We trust that the parser
                    //    has done its job correctly.
                    DisplayCommandHelp(commandArgs[0], context);
                }
                else
                {
                    // Can't be bothered to show something like 
                    // "Usage: !help [command name]" in this situation
                    // because the most likely scenario is that
                    // commandArgs[0] is whitespace and the user meant
                    // to get the whole list anyways
                    DisplayAllCommands(context);
                }
                return BaseScript.EventEat.EatGame;
            }

            private void DisplayAllCommands(CommandInvokationContext context)
            {
                Utilities.RawSayTo(context.Caller, "Please see your console for the list of commands.");
                // TODO: Up to 3 columns
                // TODO: Is it even "println" that prints to the console?
                context.Caller.Call("println", @"Use ""!help [command]"" to get usage instructions for commands.");
                foreach (var entry in _commandNames)
                {
                    context.Caller.Call("println", entry);
                }
            }

            private void DisplayCommandHelp(string command, CommandInvokationContext context)
            {
                CommandRepositoryEntry entry;
                if (!_commands.TryGetValue(command, out entry))
                {
                    DisplayAllCommands(context);
                    // "Command [command] not found" instead maybe?
                    return;
                }

                // TODO: DRY
                context.Caller.Call("println", entry.Command.Name);
                context.Caller.Call("println", "Aliases: " + String.Join(", ", entry.Command.Aliases));
                context.Caller.Call("println", "");
            }
        }
    }
}
