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
    internal class GetDocumentCommandArgument : CommandArgument
    {
        public const UserState requiredUserState = UserState.GetDocument;
        public GetDocumentCommandArgument(Message message, LibraryBotDB db, DataBase.User user) : base(message, db, user) { }

        public override bool Execute()
        {

        }
        public override IResponse CreateResponse()
        {

        }
    }
}
