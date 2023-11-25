using CookingBot.DataBase.Entities;
using CookingBot.BotBehaviors.Responses;
using CookingBot.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace CookingBot.BotBehaviors.Requests.CommandArguments
{
    internal class AddFolderCommandArgument : CommandArgument
    {
        public const UserState requiredUserState = UserState.AddFolder;
        public AddFolderCommandArgument(Message message, CookingBotDB db, CookingBot.DataBase.Entities.User user, DirectoryInfo mainDirectoryInfo) 
            : base(message, db, user, mainDirectoryInfo) { }

        public override bool Execute()
        {
            IsExecuted = base.Execute();

            //TODO create folder to storage

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
            stringBuilder.Append("Send the path to the document you are creating.\n");
            stringBuilder.Append("(Not created folders specified in the path will be created)\n");
            return stringBuilder.ToString();
        }
        }
    }
}
