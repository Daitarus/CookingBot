using LibraryBot.BotBehaviors.CommandFactory.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBot.BotBehaviors.CommandFactory
{
    internal interface IBotCommandFactory
    {
        public IBotCommand CreateBotCommand(string? commandString);
    }
}
