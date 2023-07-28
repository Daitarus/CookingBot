using LibraryBot.BotBehaviors.Requests;
using LibraryBot.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.RequestsFactories
{
    internal abstract class RequestFactory : IRequestFactory
    {
        protected LibraryBotDB db;

        public RequestFactory(LibraryBotDB db)
        {
            this.db = db;
        }

        public abstract IRequest DesignRequest(Message message, DataBase.User? user);
    }
}
