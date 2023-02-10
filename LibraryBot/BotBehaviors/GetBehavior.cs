using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace LibraryBot.BotBehaviors
{
    internal static class GetBehavior
    {
        public static async Task ResponceForGetAsync(Chat chat, ITelegramBotClient bot)
        {
            using (var stream = System.IO.File.Open(@"C:\Books\pic1.jpg", FileMode.Open))
            {
                Telegram.Bot.Types.InputFiles.InputOnlineFile iof = new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream);
                iof.FileName = "pic";
                if (iof.Content.Length < 52428800)
                {
                    await bot.SendDocumentAsync(chat, iof);
                }
            }
        }
    }
}
