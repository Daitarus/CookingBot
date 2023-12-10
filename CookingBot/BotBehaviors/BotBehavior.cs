using Telegram.Bot;
using Telegram.Bot.Types;
using CookingBot.BotBehaviors.Requests;
using CookingBot.BotBehaviors.Responses;
using TelegramService.Interfaces;
using CookingBotDB.Contexts;
using Microsoft.Extensions.Logging;
using CookingBot.BotBehaviors.Requests.Interfaces;

namespace CookingBot.BotBehaviors
{
    internal class BotBehavior : IBotBehavior
    {
        private ITelegramBotClient _telegramBotClient;
        private IRequestFactory _requestFactory;
        private DbContextFactory _dbContextFactory;
        private ILogger? _logger;

        public BotBehavior(ITelegramBotClient telegramBotClient, DbContextFactory dbContextFactory, ILogger? logger = null)
        {
            _telegramBotClient = telegramBotClient;
            //_requestFactory = new RequestFactory(dbContextFactory);
            _dbContextFactory = dbContextFactory;
            _logger = logger;
        }

        public async Task RespondForMessageAsync(Message message)
        {
            if(message == null) 
                throw new ArgumentNullException(nameof(message));

            //CookingBotDB.Entities.User? user = default;
            //if(message.From != null)
            //    user = new CookingBotDB.Entities.User(message.From);

            //user = ExchangeUserDataWithDB(user);

            //IRequest request = _requestFactory.DesignRequest(message, user);
            //IResponse response = request.CreateResponse();

            //await response.Send(_telegramBotClient, message.Chat);
        }

        //private CookingBotDB.Entities.User? GetUserFromMessage(Message message)
        //{
        //    CookingBotDB.Entities.User? user = null;

        //    if (message.From != null)
        //        user = new DataBase.User(message.From);

        //    return user;
        //}

        //private CookingBotDB.Entities.User? ExchangeUserDataWithDB(CookingBotDB.Entities.User? user)
        //{
        //    if (user != null)
        //    {
        //        UserRepository repositoryUser = new UserRepository(db);
        //        var dbUser = repositoryUser.SelectForIdTelegram(user.IdTelegram);
        //        if (dbUser == null)
        //            repositoryUser.Add(user);
        //        else
        //        {
        //            if (dbUser.Equals(user))
        //            {
        //                dbUser.UpdateMainProperties(user);
        //                user = dbUser;
        //            }
        //        }
        //        repositoryUser.SaveChanges();
        //    }
        //    return user;
        //}
    }
}
