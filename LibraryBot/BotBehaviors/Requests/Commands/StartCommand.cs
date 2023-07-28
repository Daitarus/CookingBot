using LibraryBot.BotBehaviors.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.Requests.Commands
{
    internal class StartCommand : Request
    {
        public const string commandValue = "/start";

        public StartCommand(Message message, DataBase.User user) : base(message, user) { }

        public override IResponse CreateResponse()
        {
            return new Response(CreateTextResponse(user.UserName));
        }

        private string CreateTextResponse(string userName)
        {
            return $"Hello, {userName}! Wellcome to bot!";
        }
    }
}
