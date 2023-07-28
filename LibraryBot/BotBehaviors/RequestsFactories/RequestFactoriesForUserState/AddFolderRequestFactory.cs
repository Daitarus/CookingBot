using LibraryBot.BotBehaviors.Requests;
using LibraryBot.BotBehaviors.Requests.Commands;
using LibraryBot.BotBehaviors.Requests.RequestsToCommands;
using LibraryBot.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.RequestsFactories.RequestFactoryForUserState
{
    internal class AddFolderRequestFactory : RequestFactory
    {
        public const UserState userState = UserState.AddFolder;

        public AddFolderRequestFactory(LibraryBotDB db) : base(db) { }

        public override IRequest DesignRequest(Message message, DataBase.User? user)
        {
            return message.Text switch
            {
                BackCommand.commandValue => new BackCommand(),
                _ => new AddFolderRequest()
            };
        }
    }
}
