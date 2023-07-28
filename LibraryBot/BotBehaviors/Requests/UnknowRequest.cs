using LibraryBot.BotBehaviors.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.Requests
{
    internal class UnknowRequest : Request
    {
        public UnknowRequest(Message message, DataBase.User user) : base(message, user) { }

        public override IResponse CreateResponse()
        {
            return new Response(CreateTextResponse());
        }

        private string CreateTextResponse()
        {
            return "Sorry, but your request is not recognized!";
        }
    }
}
