using LibraryBot.BotBehaviors.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.Requests.Commands
{
    internal class AddDocumentCommand : Request
    {
        public const string commandValue = "/add";

        public AddDocumentCommand(Message message, DataBase.User user) : base(message, user) { }

        public override IResponse CreateResponse()
        {

        }
    }
}
