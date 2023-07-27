using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBot.BotBehaviors.Requests;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.Requests.SpecificRequestsKit
{
    internal class BackRequest : Request
    {
        public const string commandValue = "/back";

        public override Message CreateResponse()
        {

        }
    }
}
