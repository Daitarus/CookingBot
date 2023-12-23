using CookingBot.BotBehaviors.Requests.Undefined;
using CookingBot.BotBehaviors.Responses;
using CookingBotDB.Contexts;
using CookingBotDB.Entities;
using Microsoft.Extensions.Logging;

namespace CookingBot.BotBehaviors.Requests.Commands
{
    public class UpdateRecipe : UserRequest
    {
        public const string CommandValue = "/update_recipe";

        public UpdateRecipe(DbContextFactory dbContextFacoty, User user, ILogger? logger = null) : base(dbContextFacoty, user, logger)
        {
            _assignableUserState = UserState.UpdateRecipe_Number;
        }

        //TODO Get ResponseText from file
        public override IResponse CreateResponse()
        {
            if (_isExecuted)
            {
                return new Response("Отправте номер рецепта для его изменения.");
            }
            else
            {
                return new Response("Sorry, but this request is not executed.");
            }
        }
    }
}
