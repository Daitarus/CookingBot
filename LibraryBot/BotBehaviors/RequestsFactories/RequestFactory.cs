using LibraryBot.BotBehaviors.RequestsFactories.Requests;
using LibraryBot.BotBehaviors.RequestsFactories.Requests.SpecificRequestsKit;
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
        public IRequest CreateBotCommand(Message message)
        {
            IRequest request = new Request();
            switch (message.Text)
            {
                case AddRequest.commandValue:
                    {
                        request = new AddRequest();
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
                case CreateFolderRequest.commandValue:
                    {
                        request = new CreateFolderRequest();
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
