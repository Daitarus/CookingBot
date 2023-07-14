using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using LibraryBot.DataBase;
using LibraryBot.BotBehaviors.ClientCommandFactories.ClientCommands;
using LibraryBot.BotBehaviors.ClientCommandFactories;

namespace LibraryBot.BotBehaviors
{
    internal class BotBehavior : IBotBehavior
    {
        private readonly ITelegramBotClient botClient;
        private readonly RepositoryUser repositoryUser;
        private readonly RepositoryDocument repositoryDocument;

        public BotBehavior(ITelegramBotClient botClient, LibraryBotDB db)
        {
            this.botClient = botClient;
            repositoryUser = new RepositoryUser(db);
            repositoryDocument = new RepositoryDocument(db);
        }

        public async Task RespondForMessageAsync(Message message)
        {
            DataBase.User? user = GetUserFromMessage(message);
            user = ExchangeUserDataWithDB(user);

            string? commandString = message.Text;

            IClientCommandFactory botCommandFactory = ChooseFactoryForUserState(user);
            IClientCommand command = botCommandFactory.CreateBotCommand(commandString);

            await command.Execute();
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

        private IClientCommandFactory ChooseFactoryForUserState(DataBase.User? user)
        {
            IClientCommandFactory botCommandFactory = new CommandFactoryForNullUser();
            if(user!=null)
            { 
                switch (user.State)
                {
                    case 0:
                        return new CommandFactoryForState0();
                }
            }
            return botCommandFactory;
        }
    }
}
