using CookingBot.BotBehaviors.Requests.Interfaces;
using CookingBot.BotBehaviors.Responses;
using CookingBotDB.Contexts;
using CookingBotDB.Entities;
using Microsoft.Extensions.Logging;

namespace CookingBot.BotBehaviors.Requests.Commands.AddRecipe
{
    public class AddRecipeContent : IRequest
    {
        private DbContextFactory _contextFactory;
        private User _user;
        private UserState _assignableUserState;
        private Telegram.Bot.Types.Message _message;
        private ILogger? _logger;
        private bool _isExecuted;

        public AddRecipeContent(DbContextFactory contextFactory, User user, Telegram.Bot.Types.Message message, ILogger? logger = null)
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

        public bool TryExecute()
        {

        }

        public IResponse CreateResponse()
        {
            if (_isExecuted)
            {
                return new Response("Рецепт был успешно добавлен.");
            }
            else
            {
                return new Response("Рецепт не был добавлен.");
            }
        }
    }
}
