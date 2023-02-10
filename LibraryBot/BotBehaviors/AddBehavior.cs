using Telegram.Bot.Types;
using Telegram.Bot;

namespace LibraryBot.BotBehaviors
{
    internal static class AddBehavior
    {
        public static async Task ResponceForAddAsync(Chat chat, ITelegramBotClient bot)
        {
            bot.SendTextMessageAsync(chat, "Send book's file...");
            
        }
    }
}
