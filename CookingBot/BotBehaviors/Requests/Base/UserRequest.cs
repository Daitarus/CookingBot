using CookingBot.BotBehaviors.Requests.Interfaces;
using CookingBot.BotBehaviors.Responses;
using CookingBotDB.Contexts;
using CookingBotDB.Entities;

namespace CookingBot.BotBehaviors.Requests.Base
{
    public class UserRequest : Request
    {
        const UserState _assignableUserState = UserState.Initial;

        private DbContextFactory _dbContextFacoty;
        private User _user;

        public UserRequest(DbContextFactory dbContextFacoty, User user)
        {
            if (dbContextFacoty == null)
                throw new ArgumentNullException(nameof(dbContextFacoty));
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _dbContextFacoty = dbContextFacoty;

            _user = user;
            _user.State = _assignableUserState;
        }

        public override void Execute()
        {
            using (var context = _dbContextFacoty.Create())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == _user.Id);
                user = _user;
                context.SaveChanges();
            }
        }

        public override IResponse CreateResponse()
        {
            return new Response("Sorry, but this request is not defined.");
        }
    }
}
