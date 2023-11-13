using LibraryBot.BotBehaviors.Requests;
using LibraryBot.BotBehaviors.Requests.CommandArguments;
using LibraryBot.BotBehaviors.Requests.Commands;
using LibraryBot.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.RequestsFactories
{
    internal class RequestFactory : IRequestFactory
    {
        private CookingBotDB db;
        private DirectoryInfo mainDirectoryInfo;

        public RequestFactory(CookingBotDB db, DirectoryInfo mainDirectoryInfo)
        {
            this.db = db;
            this.mainDirectoryInfo = mainDirectoryInfo;
        }

        public IRequest DesignRequest(Message message, CookingBot.DataBase.Entities.User? user)
        {
            IRequest request = new Request();
            if (user != null)
            {
                request = DesignUserRequest(message, user);
            }
            return request;
        }

        private UserRequest DesignUserRequest(Message message, CookingBot.DataBase.Entities.User user)
        {
            if(user == null) throw new ArgumentNullException(nameof(user));

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
