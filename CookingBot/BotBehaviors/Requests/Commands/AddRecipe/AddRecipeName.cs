using CookingBot.BotBehaviors.Requests.Interfaces;
using CookingBot.BotBehaviors.Responses;
using CookingBotDB.Contexts;
using CookingBotDB.Entities;
using Microsoft.Extensions.Logging;

namespace CookingBot.BotBehaviors.Requests.Commands.AddRecipe
{
    public class AddRecipeName : IRequest
    {
        private DbContextFactory _contextFactory;
        private User _user;
        private UserState _assignableUserState;
        private Telegram.Bot.Types.Message _message;
        private ILogger? _logger;
        private bool _isExecuted;

        private string _errorText;

        public AddRecipeName(DbContextFactory contextFactory, User user, Telegram.Bot.Types.Message message, ILogger? logger = null)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (_message == null)
                throw new ArgumentNullException(nameof(message));

            _assignableUserState = UserState.AddRecipe_Content;

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

                if (IsRecipeNameValid(_message.Text))
                {
                    var argumentMessage = new ArgumentMessage()
                    {
                        User = user,
                        Message = _message.Text
                    };

                    user.State = _assignableUserState;
                }

                context.SaveChanges();

                _isExecuted = true;
            }
        }

        public IResponse CreateResponse()
        {
            if (_isExecuted)
            {
                return new Response("Отправте новый рецепт текстом или файлом (Файл должен быть в формате .txt).");
            }
            else
            {
                string allErrorText = "При добавлении имени рецепта произошла ошибка!\n" + _errorText + "\nПовторите попытку ещё раз.";
                return new Response(allErrorText);
            }
        }

        private void CreateOrUpdateUserIntoDB()
        {
            using(var context = _contextFactory.Create())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == _user.Id);
                user = _user;
                context.SaveChanges();
            }
        }

        private bool IsRecipeNameValid(string? recipeName)
        {
            if (string.IsNullOrEmpty(recipeName))
            {
                _errorText = "Имя рецепта отсутствует.";
                return false;
            }

            //TODO change name length to dynamic
            if (recipeName.Length > 50)
            {
                _errorText = "Имя рецепта слишком длинное.";
                return false;
            }

            //TODO check to use only letters, numbers, underscore and space

            return true;
        }
    }
}
