using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using LibraryBot.DataBase;

namespace LibraryBot.BotBehaviors
{
    internal class MainBehavior : IBotBehavior
    {
        private RepositoryUser userR;
        private RepositoryDocument documentR;

        public MainBehavior(ITelegramBotClient client, LibraryBotDB db)
        {
            userR = new RepositoryUser(db);
            documentR = new RepositoryDocument(db);
        }

        public async Task RespondForMessageAsync(Message message)
        {
            if (message.From != null)
            {
                var user = new DataBase.User(message.From);
                user = userR.UpdateOrAddUser(user);


            }
        }
    }
}
