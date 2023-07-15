using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using LibraryBot.DataBase;
using LibraryBot.BotBehaviors.RequestsFactories;
using LibraryBot.BotBehaviors.RequestsFactories.Requests;

namespace LibraryBot.BotBehaviors
{
    internal class BotBehavior : IBotBehavior
    {
        private readonly ITelegramBotClient client;
        private readonly RepositoryUser repositoryUser;
        private readonly RepositoryDocument repositoryDocument;
        private IRequestFactory clientCommandFactory = new RequestFactory();

        public BotBehavior(ITelegramBotClient client, LibraryBotDB db)
        {
            this.client = client;
            repositoryUser = new RepositoryUser(db);
            repositoryDocument = new RepositoryDocument(db);
        }

        public async Task RespondForMessageAsync(Message message)
        {
            DataBase.User? user = GetUserFromMessage(message);
            user = ExchangeUserDataWithDB(user);
            
        }

        private DataBase.User? GetUserFromMessage(Message message)
        {
            DataBase.User? user = null;
            if (message.From != null)
            {
                user = new DataBase.User(message.From);
            }
            return user;
        }

        private DataBase.User? ExchangeUserDataWithDB(DataBase.User? user)
        {
            if (user != null)
            {
                var dbUser = repositoryUser.SelectForIdTelegram(user.IdTelegram);
                if (dbUser == null)
                {
                    repositoryUser.Add(user);
                }
                else
                {
                    if (dbUser.Equals(user))
                    {
                        dbUser.UpdateMainProperties(user);
                        user = dbUser;
                    }
                }
                repositoryUser.SaveChanges();
            }
            return user;
        }
    }
}
