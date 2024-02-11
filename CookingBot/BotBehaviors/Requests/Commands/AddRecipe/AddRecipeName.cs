using CookingBot.BotBehaviors.Requests.Interfaces;
using CookingBot.BotBehaviors.Responses;
using CookingBotDB.Contexts;
using CookingBotDB.Entities;
using CookingBotDB.Repositories;
using Microsoft.Extensions.Logging;
using System.Text;

namespace CookingBot.BotBehaviors.Requests.Commands.AddRecipe
{
    public class AddRecipeName : IRequest
    {
        public const string ArgumentMessageName = "recipeName";


        private DbContextFactory _contextFactory;

        private User _user;

        private UserState _assignableUserState = UserState.AddRecipe_Content;

        private Telegram.Bot.Types.Message _message;

        private ILogger? _logger;

        private bool _isExecuted;

        private string _errorText = string.Empty;

        private IResponse? _nestedResponse = null;

        private CookingBotRepository _repository;


        public AddRecipeName(DbContextFactory contextFactory, User user, Telegram.Bot.Types.Message message, ILogger? logger = null)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (_message == null)
                throw new ArgumentNullException(nameof(message));

            _contextFactory = contextFactory;
            _user = user;
            _message = message;
            _logger = logger;
            _repository = new CookingBotRepository(_contextFactory);
        }


        public bool TryExecute()
        {
            if (_isExecuted)
            {
                _logger?.LogWarning($"AddRecipeName command: Command has been executed previously");
                return false;
            }

            if (IsMessageValid(_message))
            {
                string recipeName = GetRecipeNameFromMessage(_message);

                if(IsRecipeNameValid(recipeName))
                {
                    _isExecuted = ExecuteThisRequest(recipeName);

                    if (IsMessageForNextCommand(recipeName, _message))
                    {
                        _isExecuted = ExecuteNestedRequest(recipeName);
                    }
                }
            }
            else
            {
                _logger?.LogWarning($"AddRecipeName command: Command is not valid");
            }

            return _isExecuted;
        }

        public IResponse CreateResponse()
        {
            if (_nestedResponse != null)
            {
                return _nestedResponse;
            }

            if (_isExecuted)
            {
                return new Response("Отправте новый рецепт текстом или файлом.");
            }
            else
            {
                string allErrorText = "При добавлении имени рецепта произошла ошибка!\n" + _errorText + "Повторите попытку ещё раз.";
                return new Response(allErrorText);
            }
        }

        private bool IsMessageValid(Telegram.Bot.Types.Message message)
        {
            if (string.IsNullOrEmpty(message.Text))
            {
                _errorText = "Имя рецепта отсутствует.\n";
                return false;
            }

            return true;
        }

        private bool IsRecipeNameValid(string recipeName)
        {
            //TODO change name length to dynamic
            if (recipeName.Length > 50)
            {
                _errorText = "Имя рецепта слишком длинное.\n";
                return false;
            }

            //TODO check to use only letters, numbers, underscore and space

            return true;
        }

        private string GetRecipeNameFromMessage(Telegram.Bot.Types.Message message)
        {
            var allLines = message.Text.Split('\n');
            return allLines[0];
        }

        private bool IsMessageForNextCommand(string recipeName, Telegram.Bot.Types.Message message)
        {
            return message.Text.Length > recipeName.Length && message.Document != null;
        }

        private bool ExecuteNestedRequest(string recipeName)
        {
            _message = UpdateMessageWithoutCommandValue(_message, recipeName.Length);

            var nestedRequest = new AddRecipeContent(_contextFactory, _user, _message, _logger);

            var isExecuted = nestedRequest.TryExecute();
            _nestedResponse = nestedRequest.CreateResponse();

            return isExecuted;
        }

        private bool ExecuteThisRequest(string recipeName)
        {
            if (_repository.TryCreateOrUpdateUser(_user))
            {
                var argumentMessage = new ArgumentMessage()
                {
                    User = _user,
                    Name = ArgumentMessageName,
                    Message = recipeName
                };

                if (_repository.TryCreateOrUpdateArgumentMessage(argumentMessage))
                {
                    return _repository.TryUpdateUserState(_user.Id, _assignableUserState);
                }
            }

            return false;
        }

        private Telegram.Bot.Types.Message UpdateMessageWithoutCommandValue(Telegram.Bot.Types.Message message, int recipeNameLength)
        {
            var messageTextBuilder = new StringBuilder(message.Text);

            messageTextBuilder.Remove(0, recipeNameLength);

            message.Text = messageTextBuilder.ToString();

            return message;
        }
    }
}
