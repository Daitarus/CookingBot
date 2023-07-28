using LibraryBot.BotBehaviors.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.Requests.Commands
{
    internal class BackCommand : Request
    {
        public const string commandValue = "/back";

        public override IResponse CreateResponse()
        {

        }
    }
}
