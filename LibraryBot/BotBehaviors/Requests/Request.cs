using LibraryBot.BotBehaviors.Responses;
using LibraryBot.DataBase;
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
        public bool IsExecute { get; protected set; }

        protected LibraryBotDB db;
        protected Message message;
        protected DataBase.User user; 

        public Request(LibraryBotDB db, Message message, DataBase.User user)
        {
            this.db = db;
            this.message = message;
            this.user = user;
        }

        public virtual bool Execute()
        {
            IsExecute = true;
            return IsExecute;
        }

        public virtual IResponse CreateResponse()
        {
            return new Response(CreateResponseText());
        }

        //TODO Get ResponseText from file
        private string CreateResponseText()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Sorry, but your request is not recognized!");
            return stringBuilder.ToString();
        }
    }
}
