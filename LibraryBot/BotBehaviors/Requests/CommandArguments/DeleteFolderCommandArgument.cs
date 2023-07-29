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
    internal class DeleteFolderCommandArgument : CommandArgument
    {
        public const UserState requiredUserState = UserState.DeleteFolder;
        public DeleteFolderCommandArgument(Message message, LibraryBotDB db, DataBase.User user, DirectoryInfo mainDirectoryInfo) 
            : base(message, db, user, mainDirectoryInfo) { }

        public override bool Execute()
        {

        }
        public override IResponse CreateResponse()
        {

        }
    }
}
