using LibraryBot.BotBehaviors.ClientCommandFactories.ClientCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBot.BotBehaviors.ClientCommandFactories
{
    internal interface IClientCommandFactory
    {
        public IClientCommand CreateBotCommand(string? commandString);
    }
}
