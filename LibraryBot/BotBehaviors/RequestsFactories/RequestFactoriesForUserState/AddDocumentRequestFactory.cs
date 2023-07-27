using LibraryBot.BotBehaviors.Requests;
using LibraryBot.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.RequestsFactories
{
    internal class AddDocumentRequestFactory : IRequestFactory
    {
        public const UserState userState = UserState.AddDocument;
        public IRequest DesignRequest(Message message, DataBase.User? user)
        {
            return message.Text switch
            {

            };
        }
    }
}
