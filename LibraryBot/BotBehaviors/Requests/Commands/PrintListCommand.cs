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
    internal class PrintListCommand : UserRequest
    {
        public const string commandValue = "/list";
        public PrintListCommand(LibraryBotDB db, DataBase.User user) : base(db, user) { }

        public override bool Execute()
        {
            //TODO GetDocumentsList
            IsExecute = TryChangeUserState();
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
            //TODO list to string
            return stringBuilder.ToString();
        }
    }
}
