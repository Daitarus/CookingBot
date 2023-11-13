﻿using Telegram.Bot;
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
        private CookingBotDB db;
        private IRequestFactory requestFactory;

        public BotBehavior(ITelegramBotClient telegramBotClient, CookingBotDB db, DirectoryInfo mainDirectoryInfo)
        {
            this.telegramBotClient = telegramBotClient;
            this.db = db;
            requestFactory = new RequestFactory(db, mainDirectoryInfo);
        }

        public async Task RespondForMessageAsync(Message message)
        {
            CookingBot.DataBase.Entities.User? user = GetUserFromMessage(message);
            user = ExchangeUserDataWithDB(user);

            IRequest request = requestFactory.DesignRequest(message, user);
            IResponse response = request.CreateResponse();

            await response.Send(telegramBotClient, message.Chat);
        }

        private CookingBot.DataBase.Entities.User? GetUserFromMessage(Message message)
        {
            CookingBot.DataBase.Entities.User? user = null;
            if (message.From != null)
                user = new DataBase.User(message.From);
            return user;
        }

        private CookingBot.DataBase.Entities.User? ExchangeUserDataWithDB(CookingBot.DataBase.Entities.User? user)
        {
            if (user != null)
            {
                UserRepository repositoryUser = new UserRepository(db);
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