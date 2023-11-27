using CookingBot.BotBehaviors.Requests.Base;
using CookingBot.BotBehaviors.Requests.CommandArguments;
using CookingBot.BotBehaviors.Requests.Commands;
using CookingBot.BotBehaviors.Requests.Interfaces;
using CookingBotDB.Contexts;
using Telegram.Bot.Types;

namespace CookingBot.BotBehaviors.Requests.Factories
{
    public class RequestFactory : IRequestFactory
    {
        private DbContextFactory _dbContextFactory;

        public RequestFactory(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IRequest Create(Message message, CookingBot.DataBase.Entities.User? user)
        {
            IRequest request = new UndefinedRequest();
            if (user != null)
            {
                request = DesignUserRequest(message, user);
            }
            return request;
        }

        private UserRequest DesignUserRequest(Message message, CookingBot.DataBase.Entities.User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            return message.Text switch
            {
                AddDocumentCommand.commandValue => new AddDocumentCommand(db, user),
                AddFolderCommand.commandValue => new AddFolderCommand(db, user),
                DeleteDocumentCommand.commandValue => new DeleteDocumentCommand(db, user),
                DeleteFolderCommand.commandValue => new DeleteFolderCommand(db, user),
                GetDocumentCommand.commandValue => new GetDocumentCommand(db, user),
                PrintListCommand.commandValue => new PrintListCommand(db, user, mainDirectoryInfo),
                _ => DesignCommandArgument(message, user)
            };
        }

        private UserRequest DesignCommandArgument(Message message, CookingBot.DataBase.Entities.User user)
        {
            return user.State switch
            {
                AddDocumentCommandArgument.requiredUserState => new AddDocumentCommandArgument(message, db, user, mainDirectoryInfo),
                AddFolderCommandArgument.requiredUserState => new AddFolderCommandArgument(message, db, user, mainDirectoryInfo),
                DeleteDocumentCommandArgument.requiredUserState => new DeleteDocumentCommandArgument(message, db, user, mainDirectoryInfo),
                DeleteFolderCommandArgument.requiredUserState => new DeleteFolderCommandArgument(message, db, user, mainDirectoryInfo),
                GetDocumentCommandArgument.requiredUserState => new GetDocumentCommandArgument(message, db, user, mainDirectoryInfo),
                _ => new UserRequest(db, user)
            };
        }
    }
}
