using CookingBot.BotBehaviors.Requests.Undefined;
using CookingBot.BotBehaviors.Responses;
using CookingBotDB.Contexts;
using CookingBotDB.Entities;
using Microsoft.Extensions.Logging;

namespace CookingBot.BotBehaviors.Requests.CommandArguments
{
    public class AddRecipeNameArguments : UserRequest
    {
        private Telegram.Bot.Types.Message _message;

        private string _errorText = string.Empty;

        public AddRecipeNameArguments(DbContextFactory dbContextFacoty, User user, Telegram.Bot.Types.Message message, ILogger? logger = null) : base(dbContextFacoty, user, logger)
        {
            if(_message == null)
                throw new ArgumentNullException(nameof(message));

            _assignableUserState = UserState.AddRecipe;
            _message = message;
        }

        public override void Execute()
        {
            if (IsRecipeNameValid(_message.Text))
            {
                _user.State = _assignableUserState;

                using (var context = _dbContextFacoty.Create())
                {
                    var user = context.Users.FirstOrDefault(u => u.Id == _user.Id);
                    user = _user;

                    var argumentMessage = new ArgumentMessage()
                    {
                        UserId = user.Id,
                        User = user,
                        Message = _message.Text
                    };

                    context.SaveChanges();

                    _isExecuted = true;
                }
            }
        }

        //TODO Get ResponseText from file
        public override IResponse CreateResponse()
        {
            if(_isExecuted)
            {
                return new Response("Отправте новый рецепт текстом или файлом (Файл должен быть в формате .txt).");
            }
            else 
            {
                string allErrorText = "При добавлении имени рецепта произошла ошибка!\n" + _errorText + "\nПовторите попытку ещё раз.";
                return new Response(allErrorText);
            }
        }

        private bool IsRecipeNameValid(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                _errorText = "Имя рецепта отсутствует.";
                return false;
            }

            //TODO change name length to dynamic
            if (name.Length > 50)
            {
                _errorText = "Имя рецепта слишком длинное.";
                return false;
            }

            //TODO check to use only letters, numbers, underscore and space

            return true;
        }
    }
}
