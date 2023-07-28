using LibraryBot.BotBehaviors.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.Requests
{
    internal class Request : IRequest
    {
        public bool IsExecute { get; } = false;

        protected Message message;
        protected DataBase.User user;     

        public Request(Message message, DataBase.User user)
        {
            this.message = message;
            this.user = user;
        }

        public virtual bool Execute() => false;

        public virtual IResponse CreateResponse()
        {
            string responseText = "Sorry, but your request is not recognized!";
            return new Response(responseText);
        }
    }
}
