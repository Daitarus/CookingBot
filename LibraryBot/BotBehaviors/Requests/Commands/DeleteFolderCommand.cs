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

        public override Message CreateResponse()
        {

        }
    }
}
