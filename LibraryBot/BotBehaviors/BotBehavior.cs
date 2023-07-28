using Telegram.Bot;
using Telegram.Bot.Types;
using LibraryBot.DataBase;
using LibraryBot.BotBehaviors.RequestsFactories;
using LibraryBot.BotBehaviors.Responses;
using LibraryBot.BotBehaviors.Requests;

namespace LibraryBot.BotBehaviors
{
    internal class BotBehavior : IBotBehavior
    {
        private readonly ITelegramBotClient telegramBotClient;
        private readonly RepositoryUser repositoryUser;
        private IRequestFactory requestFactory;

        public BotBehavior(ITelegramBotClient telegramBotClient, LibraryBotDB db)
        {
            this.telegramBotClient = telegramBotClient;
            repositoryUser = new RepositoryUser(db);
            requestFactory = new MainRequestFactory(db);
        }

        public async Task RespondForMessageAsync(Message message)
        {
            DataBase.User? user = GetUserFromMessage(message);
            user = ExchangeUserDataWithDB(user);

            IRequest request = requestFactory.DesignRequest(message, user);
            IResponse response = request.CreateResponse();

            await response.Send(telegramBotClient, message.Chat);
        }

        private DataBase.User? GetUserFromMessage(Message message)
        {
            DataBase.User? user = null;
            if (message.From != null)
                user = new DataBase.User(message.From);
            return user;
        }

        private DataBase.User? ExchangeUserDataWithDB(DataBase.User? user)
        {
            if (user != null)
            {
                var dbUser = repositoryUser.SelectForIdTelegram(user.IdTelegram);
                if (dbUser == null)
                    repositoryUser.Add(user);
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
