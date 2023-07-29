using LibraryBot.BotBehaviors.Responses;
using LibraryBot.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.Requests.Commands
{
    internal class DeleteDocumentCommand : UserRequest
    {
        public const string commandValue = "/delete";

        public DeleteDocumentCommand(LibraryBotDB db, DataBase.User user) : base(db, user)
        {
            assignableUserState = UserState.DeleteDocument;
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
