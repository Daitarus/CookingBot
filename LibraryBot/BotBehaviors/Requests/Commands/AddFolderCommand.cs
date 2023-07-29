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
    internal class AddFolderCommand : Request
    {
        public const string commandValue = "/cfolder";

        public AddFolderCommand(LibraryBotDB db, Message message, DataBase.User user) : base(db, message, user) { }

        public override bool Execute()
        {
            UserRepository userRepository = new UserRepository(db);
            user.State = UserState.AddFolder;
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
            stringBuilder.Append("Send the path for the folder!\n");
            stringBuilder.Append("(Not created folders specified in the path will be created)\n");
            return stringBuilder.ToString();
        }
    }
}
