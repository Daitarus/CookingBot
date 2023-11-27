using CookingBot.BotBehaviors.Requests.Base;
using CookingBot.BotBehaviors.Responses;
using CookingBot.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace CookingBot.BotBehaviors.Requests.Commands
{
    internal class StartCommand : UserRequest
    {
        public const string commandValue = "/start";

        public StartCommand(CookingBotDB db, CookingBot.DataBase.Entities.User user) : base(db, user) { }

        public override IResponse CreateResponse()
        {
            return new Response(CreateResponseText());
        }

        //TODO Get ResponseText from file
        private string CreateResponseText()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Hello ");

            if (_user.UserName != null)
                stringBuilder.Append(_user.UserName);
            else
                stringBuilder.Append(_user.FirstName);

            stringBuilder.Append("! ! Wellcome to bot.");
            return stringBuilder.ToString();
        }
    }
}
