using CookingBot.BotBehaviors.Requests.Interfaces;
using CookingBot.BotBehaviors.Responses;
using CookingBotDB.Contexts;
using CookingBotDB.Entities;
using Microsoft.Extensions.Logging;
using System.Text;

namespace CookingBot.BotBehaviors.Requests.Commands.AddRecipe
{
    public class AddRecipe : IRequest
    {
        public const string CommandValue = "/add_recipe";


        private DbContextFactory _contextFactory;

        private User _user;

        private const UserState _assignableUserState = UserState.AddRecipe_Name;

        private Telegram.Bot.Types.Message _message;

        private ILogger? _logger;

        private bool _isExecuted;

        private IResponse? _nestedResponse = null;


        public AddRecipe(DbContextFactory contextFactory, User user, Telegram.Bot.Types.Message message, ILogger? logger = null)
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
        }


        public bool TryExecute()
        {
            if(_isExecuted)
            {
                _logger?.LogWarning($"AddRecipe command: Command has been executed previously");
                return false;
            }

            if(IsMessageValid(_message))
            {
                _isExecuted = ExecuteThisRequest();

                if (IsMessageForNextCommand(_message))
                {
                    _isExecuted = ExecuteNestedRequest();
                }
            }
            else
            {
                _logger?.LogWarning($"AddRecipe command: Command is not valid");
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
                return new Response("Отправте уникальное имя для рецепта, который хотите добавить.");
            }
            else
            {
                return new Response($"Произошла ошибка при выполнении команды!");
            }
        }


        private bool IsMessageValid(Telegram.Bot.Types.Message message)
        {
            if (!string.IsNullOrEmpty(message.Text))
            {
                var probableCommandValue = message.Text.Substring(0, CommandValue.Length);

                return CommandValue.Equals(probableCommandValue);
            }

            return false;
        }

        private bool IsMessageForNextCommand(Telegram.Bot.Types.Message message)
        {
            return message.Text.Length > CommandValue.Length;
        }

        private bool ExecuteNestedRequest()
        {
            _message = UpdateMessageWithoutCommandValue(_message);

            var nestedRequest = new AddRecipeName(_contextFactory, _user, _message, _logger);

            var isExecuted = nestedRequest.TryExecute();
            _nestedResponse = nestedRequest.CreateResponse();

            return isExecuted;
        }

        private bool ExecuteThisRequest()
        {
            if (TryCreateOrUpdateUserIntoDB())
            {
                using (var context = _contextFactory.Create())
                {
                    var user = context.Users.First(u => u.Id == _user.Id);
                    user.State = _assignableUserState;
                    var updatedQuantity = context.SaveChanges();

                    return updatedQuantity > 0;
                }
            }

            return false;
        }

        private Telegram.Bot.Types.Message UpdateMessageWithoutCommandValue(Telegram.Bot.Types.Message message)
        {
            var messageTextBuilder = new StringBuilder(message.Text);

            messageTextBuilder.Remove(0, CommandValue.Length);

            message.Text = messageTextBuilder.ToString();

            return message;
        }

        private bool TryCreateOrUpdateUserIntoDB()
        {
            using (var context = _contextFactory.Create())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == _user.Id);

                if (user == default)
                {
                    context.Users.Add(_user);
                }
                else
                {
                    user = _user;
                }

                var updatedQuantity = context.SaveChanges();

                return updatedQuantity > 0;
            }
        }
    }
}
