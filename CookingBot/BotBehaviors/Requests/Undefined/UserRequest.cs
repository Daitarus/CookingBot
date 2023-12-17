using CookingBotDB.Contexts;
using CookingBotDB.Entities;
using Microsoft.Extensions.Logging;

namespace CookingBot.BotBehaviors.Requests.Undefined
{
    public class UserRequest : Request
    {
        protected UserState _assignableUserState;

        protected DbContextFactory _dbContextFacoty;
        protected User _user;
        protected ILogger? _logger;

        public UserRequest(DbContextFactory dbContextFacoty, User user, ILogger? logger = null)
        {
            if (dbContextFacoty == null)
                throw new ArgumentNullException(nameof(dbContextFacoty));
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _assignableUserState = UserState.Initial;

            _dbContextFacoty = dbContextFacoty;
            _user = user;
            _logger = logger;
        }

        public override void Execute()
        {
            _user.State = _assignableUserState;

            using (var context = _dbContextFacoty.Create())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == _user.Id);
                user = _user;
                context.SaveChanges();

                _isExecuted = true;
            }
        }
    }
}
