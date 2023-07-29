using LibraryBot.BotBehaviors.Requests;
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
    internal abstract class RequestFactory : IRequestFactory
    {
        protected LibraryBotDB db;

        public RequestFactory(LibraryBotDB db)
        {
            this.db = db;
        }

        public abstract IRequest DesignRequest(Message message, DataBase.User? user);

        public IRequest DesignRequest(Message message, DataBase.User? user)
        {
            IRequest request = new Request(db, message, user);
            if (user != null)
            {
                return message.Text switch
                {
                    AddDocumentCommand.commandValue => new AddDocumentCommand(db, message, user),
                    AddFolderCommand.commandValue => new AddFolderCommand(db, message, user),
                    DeleteDocumentCommand.commandValue => new DeleteDocumentCommand(db, message, user),
                    DeleteFolderCommand.commandValue => new DeleteFolderCommand(db, message, user),
                    GetDocumentCommand.commandValue => new GetRequestCommand(db, message, user),
                    PrintListCommand.commandValue => new PrintListCommand(db, message, user),
                    _ => GetRequestForUserState(user)
                };
            }
            return request;
        }

        private IRequest GetRequestForUserState(DataBase.User user)
        {

        }
    }
}
