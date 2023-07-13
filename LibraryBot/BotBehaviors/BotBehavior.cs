using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using LibraryBot.DataBase;
using LibraryBot.BotBehaviors.CommandFactory.Commands;
using LibraryBot.BotBehaviors.CommandFactory;

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
            string? commandString = null;
            if (message.From != null)
            {
                var userFromTelegram = new DataBase.User(message.From);
                var userFromDB = repositoryUser.SelectForIdTelegram(userFromTelegram.IdTelegram);
                if(userFromDB == null)
                {
                    repositoryUser.Add(userFromTelegram);
                    userFromDB = userFromTelegram;
                }
                else
                {
                    if(userFromDB.Equals(userFromTelegram))
                    {
                        userFromDB.Update(userFromTelegram);
                    }
                }
                repositoryUser.SaveChanges();

                commandString = message.Text;
            }

            IBotCommandFactory botCommandFactory = new BotCommandFactory();
            IBotCommand command = botCommandFactory.CreateBotCommand(commandString);

            await command.Execute();
        }
    }
}
