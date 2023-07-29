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
    internal class InitialRequestFactory : RequestFactory
    {
        public const UserState userState = UserState.Initial;

        public InitialRequestFactory(LibraryBotDB db) : base(db) { }

        public override IRequest DesignRequest(Message message, DataBase.User? user)
        {
            return message.Text switch
            {
                AddDocumentCommand.commandValue => new AddDocumentCommand(),
                AddFolderCommand.commandValue => new AddFolderCommand(),
                DeleteDocumentCommand.commandValue => new DeleteDocumentCommand(),
                DeleteFolderCommand.commandValue => new DeleteFolderCommand(),
                GetDocumentCommand.commandValue => new GetRequestCommand(),
                PrintListCommand.commandValue => new PrintListCommand(),
                _ => new Request()
            };
        }
    }
}
