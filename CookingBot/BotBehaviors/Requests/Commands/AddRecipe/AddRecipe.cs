using CookingBot.BotBehaviors.Requests.Interfaces;
using CookingBot.BotBehaviors.Responses;
using CookingBotDB.Contexts;
using CookingBotDB.Entities;
using Microsoft.Extensions.Logging;

namespace CookingBot.BotBehaviors.Requests.Commands.AddRecipe
{
    public class AddRecipe : IRequest
    {
        private DbContextFactory _contextFactory;
        private User _user;
        private UserState _assignableUserState;
        private Telegram.Bot.Types.Message _message;
        private ILogger? _logger;
        private bool _isExecuted;

        public AddRecipe(DbContextFactory contextFactory, User user, Telegram.Bot.Types.Message message, ILogger? logger = null)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (_message == null)
                throw new ArgumentNullException(nameof(message));

            _assignableUserState = UserState.AddRecipe_Name;

            _contextFactory = contextFactory;
            _user = user;
            _message = message;
            _logger = logger;
        }

        public void Execute()
        {
            CreateOrUpdateUserIntoDB();

            using (var context = _contextFactory.Create())
            {
                var user = context.Users.First(u => u.Id == _user.Id);
                user.State = _assignableUserState;
                context.SaveChanges();

                _isExecuted = true;
            }
        }

        public IResponse CreateResponse()
        {
            if (_isExecuted)
            {
                return new Response("Отправте имя рецепта, который хотите добавить.");
            }
            else
            {
                return new Response("Произошла ошибка!");
            }
        }

        private void CreateOrUpdateUserIntoDB()
        {
            using (var context = _contextFactory.Create())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == _user.Id);
                user = _user;
                context.SaveChanges();
            }
        }
    }
}
