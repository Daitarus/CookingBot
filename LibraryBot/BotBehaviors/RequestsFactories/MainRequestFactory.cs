using LibraryBot.BotBehaviors.Requests;
using LibraryBot.BotBehaviors.Requests.SpecificRequestsKit;
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
        private readonly RepositoryDocument repositoryDocument;

        public MainRequestFactory(RepositoryDocument repositoryDocument) 
        {  
            this.repositoryDocument = repositoryDocument; 
        }

        public IRequest DesignRequest(Message message, DataBase.User? user)
        {
            IRequest request = new Request();
            switch (message.Text)
            {
                case AddDocumentRequest.commandValue:
                    {
                        request = new AddDocumentRequest();
                        break;
                    }
                case GetRequest.commandValue:
                    {
                        request = new GetRequest();
                        break;
                    }
                case DeleteCommand.commandValue:
                    {
                        request = new DeleteCommand();
                        break;
                    }
                case AddFolderRequest.commandValue:
                    {
                        request = new AddFolderRequest();
                        break;
                    }
                case DeleteFolderCommand.commandValue:
                    {
                        request = new DeleteFolderCommand();
                        break;
                    }
                case PrintListRequest.commandValue:
                    {
                        request = new PrintListRequest();
                        break;
                    }
            }
            return request;
        }
    }
}
