using LibraryBot.DataBase;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace LibraryBot.BotBehaviors
{
    internal static class AuthorizationBehavior
    {
        public static async Task ResponseForAuthorization(Message message, DataBase.User user, ITelegramBotClient bot)
        {
            if(!string.IsNullOrEmpty(message.Text))
            {
                if(message.Text.Equals(Commands.Start))
                {
                    await CommandsBehavior.ResponceForStartAsync(message.Chat, bot);
                }
                else
                {

                }
            }
        }
    }
}
