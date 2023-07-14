using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBot.BotBehaviors.ClientCommandFactories.ClientCommands
{
    internal interface IClientCommand
    {
        public Task Execute();
    }
}
