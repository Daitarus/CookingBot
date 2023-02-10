using Telegram.Bot.Types;
using Telegram.Bot;

namespace LibraryBot.BotBehaviors
{
    internal static class StartBehavior
    {
        public static async Task ResponceForStartAsync(Chat chat, ITelegramBotClient bot)
        {
            await bot.SendTextMessageAsync(chat, "Welcome to LibraryBot!!!");
        }
    }
}
