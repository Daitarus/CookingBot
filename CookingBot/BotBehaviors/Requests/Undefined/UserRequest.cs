using CookingBot.BotBehaviors.Requests.Interfaces;
using CookingBot.BotBehaviors.Responses;
using CookingBotDB.Contexts;
using CookingBotDB.Entities;

namespace CookingBot.BotBehaviors.Requests.Undefined
{
    public class UserRequest : IRequest
    {
        private const UserState _assignableUserState = UserState.Initial;

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
        }

        public void Execute()
        {
            _user.State = _assignableUserState;

            using (var context = _dbContextFacoty.Create())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == _user.Id);
                user = _user;
                context.SaveChanges();
            }
        }

        public IResponse CreateResponse()
        {
            return new Response("Sorry, but this request is not defined.");
        }
    }
}
