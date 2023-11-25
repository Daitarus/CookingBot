using CookingBot.DataBase.Entities;
using CookingBot.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace CookingBot.BotBehaviors.Requests.CommandArguments
{
    internal abstract class CommandArgument : UserRequest
    {
        protected Message message;
        protected DirectoryInfo mainDirectoryInfo;
        public CommandArgument(Message message, CookingBotDB db, CookingBot.DataBase.Entities.User user, DirectoryInfo mainDirectoryInfo) : base (db, user)
        {
            if(message == null) throw new ArgumentNullException (nameof(message));

            this.message = message;
            this.mainDirectoryInfo = mainDirectoryInfo;
            _assignableUserState = UserState.Initial;
        }
    }
}
