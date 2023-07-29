using LibraryBot.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.Requests.CommandArguments
{
    internal abstract class CommandArgument : UserRequest
    {
        protected Message message;
        public CommandArgument(Message message, LibraryBotDB db, DataBase.User user) : base (db, user)
        {
            if(message == null) throw new ArgumentNullException (nameof(message));

            this.message = message;
            assignableUserState = UserState.Initial;
        }
    }
}
