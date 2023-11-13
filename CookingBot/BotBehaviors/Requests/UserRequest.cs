using CookingBot.DataBase.Entities;
using LibraryBot.BotBehaviors.Responses;
using LibraryBot.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Requests.Abstractions;

namespace LibraryBot.BotBehaviors.Requests
{
    internal class UserRequest : Request
    {
        public UserState assignableUserState { get; protected set; } = UserState.Initial;

        protected CookingBotDB db;
        protected User user;

        public UserRequest(CookingBotDB db, User user)
        {
            if(db == null) throw new ArgumentNullException(nameof(db));
            if (user == null) throw new ArgumentNullException(nameof(user));

            this.db = db;
            this.user = user;
        }

        public override bool Execute()
        {
            IsExecuted = TryChangeUserState();
            return IsExecuted;
        }

        protected bool TryChangeUserState()
        {
            user.State = assignableUserState;
            return TrySaveUser();
        }
        private bool TrySaveUser()
        {
            UserRepository userRepository = new UserRepository(db);
            try
            {
                userRepository.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //TODO log ex
                return false;
            }
        }

        public override IResponse CreateResponse()
        {
            return new Response("Sorry, but your request was not recognized.");
        }
    }
}
