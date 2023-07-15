using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.InputFiles;

namespace LibraryBot.BotBehaviors.Response
{
    internal class Response : IResponse
    {
        public string Text { get; }
        public InputOnlineFile File { get; }
        public Response(string text, InputOnlineFile file)
        {
            Text = text;
            File = file;
        }
    }
}
