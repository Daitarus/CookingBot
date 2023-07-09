using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using LibraryBot.DataBase;
using LibraryBot.BotBehaviors.Commands;

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
            if (message.From != null)
            {
                var user = new DataBase.User(message.From);
                repositoryUser.UpdateOrAddForTelegramId(user);

                IBotCommand command = CommandDefinition(message.Text);

                await command.Execute();

                repositoryUser.SaveChanges();
            }
        }

        private IBotCommand CommandDefinition(string? commandValue)
        {
            IBotCommand command = new UnknownCommand();
            switch (commandValue)
            {
                case AddCommand.commandValue:
                    {
                        command = new AddCommand();
                        break;
                    }
                case GetCommand.commandValue:
                    {
                        command = new GetCommand();
                        break;
                    }
                case DeleteCommand.commandValue:
                    {
                        command = new DeleteCommand();
                        break;
                    }
                case CreateFolderCommand.commandValue:
                    {
                        command = new CreateFolderCommand();
                        break;
                    }
                case DeleteFolderCommand.commandValue:
                    {
                        command = new DeleteFolderCommand();
                        break;
                    }
                case PrintListCommand.commandValue:
                    {
                        command = new PrintListCommand();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return command;
        }
    }
}
