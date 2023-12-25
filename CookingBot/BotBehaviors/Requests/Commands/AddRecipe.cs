using CookingBot.BotBehaviors.Responses;
using CookingBotDB.Entities;
using CookingBotDB.Contexts;
using CookingBot.BotBehaviors.Requests.Undefined;
using Microsoft.Extensions.Logging;

namespace CookingBot.BotBehaviors.Requests.Commands
{
    public class AddRecipe : UserRequest
    {
        public const string CommandValue = "/add_recipe";

        public AddRecipe(DbContextFactory dbContextFacoty, User user, ILogger? logger = null) : base(dbContextFacoty, user, logger) 
        {
            _assignableUserState = UserState.AddRecipe_Name;
        }

        //TODO Get ResponseText from file
        public override IResponse CreateResponse()
        {
            if (_isExecuted)
            {
                return new Response("Отправте имя рецепта нового рецепта.");
            }
            else
            {
                return new Response("Sorry, but this request is not executed.");
            }
        }
    }
}
