using Telegram.Bot.Types;
using Telegram.Bot;

namespace LibraryBot.BotBehaviors
{
    internal class CommandsBehavior
    {
        public static async Task ResponceForStartAsync(Chat chat, ITelegramBotClient bot)
        {
            await bot.SendTextMessageAsync(chat, "Welcome to LibraryBot!!!");
        }
        public static async Task ResponceForAddAsync(Chat chat, ITelegramBotClient bot)
        {
            await bot.SendTextMessageAsync(chat, "Send book's file...");
        }
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
        public static async Task ResponceForDeleteAsync(Chat chat, ITelegramBotClient bot)
        {

        }
        public static async Task ResponceForCreateFolderAsync(Chat chat, ITelegramBotClient bot)
        {

        }
        public static async Task ResponceForDeleteFolderAsync(Chat chat, ITelegramBotClient bot)
        {

        }
        public static async Task ResponceForPrintListAsync(Chat chat, ITelegramBotClient bot)
        {

        }
        public static async Task ResponceForBackAsync(Chat chat, ITelegramBotClient bot)
        {

        }
    }
}
