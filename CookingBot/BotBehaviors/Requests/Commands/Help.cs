using CookingBot.BotBehaviors.Requests.Undefined;
using CookingBot.BotBehaviors.Responses;
using CookingBotDB.Contexts;
using CookingBotDB.Entities;
using Microsoft.Extensions.Logging;
using System.Text;

namespace CookingBot.BotBehaviors.Requests.Commands
{
    public class Help : UserRequest
    {
        public const string CommandValue = "/help";

        public Help(DbContextFactory dbContextFacoty, User user, ILogger? logger = null) : base(dbContextFacoty, user, logger)
        {
            _assignableUserState = UserState.Initial;
        }

        //TODO Get ResponseText from file
        public override IResponse CreateResponse()
        {
            if (_isExecuted)
            {
                return new Response(CreateResponseText());
            }
            else
            {
                return new Response("Sorry, but this request is not executed.");
            }
        }

        private string CreateResponseText()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Список команд для работы с ботом:\n");
            stringBuilder.Append("- /start - начало работы с ботом\n");
            stringBuilder.Append("- /help - получить список возможных команд для работы с ботом\n");
            stringBuilder.Append("- /add_recipe - добавить новый рецепт\n");
            stringBuilder.Append("- /get_recipe - получить рецепт\n");
            stringBuilder.Append("- /get_recipes_list - получить список всех своих рецептов\n");
            stringBuilder.Append("- /delete_recipe - удалить рецепт\n");
            stringBuilder.Append("- /update_recipe - обновить данные уже добавленного рецепта\n");

            return stringBuilder.ToString();
        }
    }
}
