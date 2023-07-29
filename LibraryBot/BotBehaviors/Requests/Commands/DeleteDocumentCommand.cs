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
    internal class DeleteDocumentCommand : Request
    {
        public const string commandValue = "/delete";

        public DeleteDocumentCommand(LibraryBotDB db, Message message, DataBase.User user) : base(db, message, user) { }

        public override bool Execute()
        {
            UserRepository userRepository = new UserRepository(db);
            user.State = UserState.DeleteDocument;
            db.SaveChanges();

            IsExecute = true;
            return IsExecute;
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
