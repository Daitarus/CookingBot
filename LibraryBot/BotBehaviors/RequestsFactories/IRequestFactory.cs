using LibraryBot.BotBehaviors.RequestsFactories.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.RequestsFactories
{
    internal interface IRequestFactory
    {
        public IRequest CreateBotCommand(Message message);
    }
}
