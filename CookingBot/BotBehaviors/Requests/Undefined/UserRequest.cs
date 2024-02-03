using CookingBotDB.Contexts;
using CookingBotDB.Entities;
using Microsoft.Extensions.Logging;

namespace CookingBot.BotBehaviors.Requests.Undefined
{
    public class UserRequest : Request
    {
        protected DbContextFactory _contextFactory;
        protected User _user;
        protected ILogger? _logger;

        public UserRequest(DbContextFactory contextFactory, User user, ILogger? logger = null)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _contextFactory = contextFactory;
            _user = user;
            _logger = logger;
        }

        public override void Execute()
        {
            using (var context = _contextFactory.Create())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == _user.Id);
                user = _user;
                context.SaveChanges();

                _isExecuted = true;
            }
        }
    }
}
