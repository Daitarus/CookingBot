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
    internal class DeleteDocumentCommand : UserRequest
    {
        public const string commandValue = "/delete";

        public DeleteDocumentCommand(CookingBotDB db, CookingBot.DataBase.Entities.User user) : base(db, user)
        {
            _assignableUserState = UserState.DeleteDocument;
        }

        public override IResponse CreateResponse()
        {
            return new Response(CreateResponseText());
        }

        //TODO Get ResponseText from file
        private string CreateResponseText()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Send the path to the document you are deleting.\n");
            return stringBuilder.ToString();
        }
    }
}
