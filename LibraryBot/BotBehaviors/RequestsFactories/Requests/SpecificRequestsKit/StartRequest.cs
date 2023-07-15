using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBot.BotBehaviors.RequestsFactories.Requests;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.RequestsFactories.Requests.SpecificRequestsKit
{
    internal class StartRequest : Request
    {
        public const string commandValue = "/start";
        public override Message CreateRespondingMessage()
        {

        }
    }
}
