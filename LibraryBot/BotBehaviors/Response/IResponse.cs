using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.InputFiles;

namespace LibraryBot.BotBehaviors.Response
{
    internal interface IResponse
    {
        public string? Text { get; }
        public InputOnlineFile? File { get; }       
    }
}
