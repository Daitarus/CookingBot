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
    internal class DeleteFolderCommand : Request
    {
        public const string commandValue = "/dfolder";

        public DeleteFolderCommand(LibraryBotDB db, Message message, DataBase.User user) : base(db, message, user) { }

        public override bool Execute()
        {
            UserRepository userRepository = new UserRepository(db);
            user.State = UserState.DeleteFolder;
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
            stringBuilder.Append("Send the path to the folder you are deleting.\n");
            stringBuilder.Append("(All folders and documents in deleting folder will be deleted)\n");
            return stringBuilder.ToString();
        }
    }
}
