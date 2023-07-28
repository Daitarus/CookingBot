using LibraryBot.BotBehaviors.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.Requests
{
    internal class Request : IRequest
    {
        protected Message message;
        protected DataBase.User user;

        public Request(Message message, DataBase.User user)
        {
            this.message = message;
            this.user = user;
        }

        public virtual IResponse CreateResponse()
        {
            
        }
    }
}
