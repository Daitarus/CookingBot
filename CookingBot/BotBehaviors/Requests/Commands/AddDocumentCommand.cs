using CookingBot.DataBase.Entities;
using CookingBot.BotBehaviors.Responses;
using CookingBot.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using CookingBot.BotBehaviors.Requests.Base;

namespace CookingBot.BotBehaviors.Requests.Commands
{
    internal class AddDocumentCommand : UserRequest
    {
        public const string commandValue = "/add";

        public AddDocumentCommand(CookingBotDB db, CookingBot.DataBase.Entities.User user) : base(db, user) 
        {
            _assignableUserState = UserState.AddDocument;
        }

        public override IResponse CreateResponse()
        {
            return new Response(CreateResponseText());
        }

        //TODO Get ResponseText from file
        private string CreateResponseText()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Send the path to the document you are creating.\n");
            stringBuilder.Append("(Not created folders specified in the path will be created)\n");
            return stringBuilder.ToString();
        }
    }
}
