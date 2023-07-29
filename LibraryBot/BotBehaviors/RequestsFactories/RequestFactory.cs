using LibraryBot.BotBehaviors.Requests;
using LibraryBot.BotBehaviors.Requests.Commands;
using LibraryBot.BotBehaviors.Responses;
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
        protected LibraryBotDB db;

        public RequestFactory(LibraryBotDB db)
        {
            this.db = db;
        }

        public IRequest DesignRequest(Message message, DataBase.User? user)
        {
            IRequest request = new Request();
            if (user != null)
            {
                request = DesignUserRequest(message, user);
            }
            return request;
        }

        private UserRequest DesignUserRequest(Message message, DataBase.User user)
        {
            if(user == null) throw new ArgumentNullException(nameof(user));

            return message.Text switch
            {
                AddDocumentCommand.commandValue => new AddDocumentCommand(db, user),
                AddFolderCommand.commandValue => new AddFolderCommand(db, user),
                DeleteDocumentCommand.commandValue => new DeleteDocumentCommand(db, user),
                DeleteFolderCommand.commandValue => new DeleteFolderCommand(db, user),
                GetDocumentCommand.commandValue => new GetDocumentCommand(db, user),
                PrintListCommand.commandValue => new PrintListCommand(db, user),
                _ => DesignRequestToCommands(message, user)
            };
        }

        private UserRequest DesignRequestToCommands(Message message, DataBase.User user)
        {
            return user.State switch
            {

            };
        }
    }
}
