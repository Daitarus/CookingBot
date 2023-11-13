using LibraryBot.BotBehaviors.Requests;
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
        public IRequest DesignRequest(Message message, CookingBot.DataBase.Entities.User? user);
    }
}
