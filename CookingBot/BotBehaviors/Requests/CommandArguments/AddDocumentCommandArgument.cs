using CookingBot.DataBase.Entities;
using LibraryBot.BotBehaviors.Responses;
using LibraryBot.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.Requests.CommandArguments
{
    internal class AddDocumentCommandArgument : CommandArgument
    {
        public const UserState requiredUserState = UserState.AddDocument;
        public AddDocumentCommandArgument(Message message, CookingBotDB db, CookingBot.DataBase.Entities.User user, DirectoryInfo mainDirectoryInfo) 
            : base(message, db, user, mainDirectoryInfo) { }

        public override bool Execute()
        {
            IsExecuted = base.Execute();

            //TODO Add document to DB and to storage

            return IsExecuted;
        }
        public override IResponse CreateResponse()
        {
            return new Response(CreateResponseText());
        }

        //TODO Get ResponseText from file
        private string CreateResponseText()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsExecuted)
            {
                stringBuilder.Append("Document has been added.\n");
            }
            else
            {
                stringBuilder.Append("Error: Document was not added!\n");
            }
            return stringBuilder.ToString();
        }
    }
}
