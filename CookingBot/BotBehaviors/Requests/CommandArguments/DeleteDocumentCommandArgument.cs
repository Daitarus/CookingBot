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
    internal class DeleteDocumentCommandArgument : CommandArgument
    {
        public const UserState requiredUserState = UserState.DeleteDocument;
        public DeleteDocumentCommandArgument(Message message, CookingBotDB db, CookingBot.DataBase.Entities.User user, DirectoryInfo mainDirectoryInfo) 
            : base(message, db, user, mainDirectoryInfo) { }

        public override bool Execute()
        {

        }
        public override IResponse CreateResponse()
        {

        }
    }
}
