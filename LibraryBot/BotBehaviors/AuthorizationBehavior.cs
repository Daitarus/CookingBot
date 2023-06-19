using LibraryBot.DataBase;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace LibraryBot.BotBehaviors
{
    internal class AuthorizationBehavior
    {
        private ITelegramBotClient bot;

        public AuthorizationBehavior(ITelegramBotClient bot) 
        {
            this.bot = bot;
        }

        public async Task RespondForAuthorization(Message message, DataBase.User user)
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
            else
            {
                //TODO: print "please, enter your key"
            }
        }
    }
}
