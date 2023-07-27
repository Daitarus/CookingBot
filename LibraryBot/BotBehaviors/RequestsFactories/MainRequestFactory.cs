using LibraryBot.BotBehaviors.Requests;
using LibraryBot.BotBehaviors.Requests.SpecificRequestsKit;
using LibraryBot.BotBehaviors.RequestsFactories.RequestFactoryForUserState;
using LibraryBot.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.RequestsFactories
{
    internal class MainRequestFactory : IRequestFactory
    {
        public IRequest DesignRequest(Message message, DataBase.User? user)
        {
            IRequest request = new Request();
            if(user != null)
            {
                IRequestFactory requestFactory = GetRequestFactoryForUserState(user);
                request = requestFactory.DesignRequest(message, user);
            }
            return request;
        }
        private IRequestFactory GetRequestFactoryForUserState(DataBase.User user)
        {
            return user.State switch
            {
                AddDocumentRequestFactory.userState => new AddDocumentRequestFactory(),
                AddFolderRequestFactory.userState => new AddDocumentRequestFactory(),
                DeleteDocumentRequestFactory.userState => new DeleteDocumentRequestFactory(),
                DeleteFolderRequestFactory.userState => new DeleteFolderRequestFactory(),
                InitialRequestFactory.userState => new InitialRequestFactory(),
                _ => new InitialRequestFactory()
            };
        }        
    }
}
