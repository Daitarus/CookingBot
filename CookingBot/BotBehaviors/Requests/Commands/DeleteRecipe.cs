using CookingBot.BotBehaviors.Requests.Undefined;
using CookingBot.BotBehaviors.Responses;
using CookingBotDB.Contexts;
using CookingBotDB.Entities;
using Microsoft.Extensions.Logging;

namespace CookingBot.BotBehaviors.Requests.Commands
{
    public class DeleteRecipe : UserRequest
    {
        public const string CommandValue = "/delete_recipe";

        public DeleteRecipe(DbContextFactory dbContextFacoty, User user, ILogger? logger = null) : base(dbContextFacoty, user, logger)
        {
            _assignableUserState = UserState.DeleteRecipe;
        }

        //TODO Get ResponseText from file
        public override IResponse CreateResponse()
        {
            if (_isExecuted)
            {
                return new Response("Отправте номер рецепта для его удаления.");
            }
            else
            {
                return new Response("Sorry, but this request is not executed.");
            }
        }
    }
}
