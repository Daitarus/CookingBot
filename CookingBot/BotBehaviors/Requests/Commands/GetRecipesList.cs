using CookingBot.BotBehaviors.Requests.Undefined;
using CookingBot.BotBehaviors.Responses;
using CookingBotDB.Contexts;
using CookingBotDB.Entities;
using Microsoft.Extensions.Logging;
using System.Text;

namespace CookingBot.BotBehaviors.Requests.Commands
{
    public class GetRecipesList : UserRequest
    {
        public const string CommandValue = "/get_recipes_list";

        private IList<Recipe>? _userRecipes;

        public GetRecipesList(DbContextFactory dbContextFacoty, User user, ILogger? logger = null) : base (dbContextFacoty, user, logger)
        {
            _assignableUserState = UserState.Initial;
        }

        public override void Execute()
        {
            _user.State = _assignableUserState;

            using (var context = _contextFactory.Create())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == _user.Id);
                user = _user;

                _userRecipes = context.Recipes.Where(recipe => recipe.UserId == user.Id).ToList();

                context.SaveChanges();

                _isExecuted = true;
            }
        }

        public override IResponse CreateResponse()
        {
            if (_isExecuted)
            {
                return new Response(CreateMessageFromRecipesList());
            }
            else
            {
                return new Response("Sorry, but this request is not executed.");
            }
        }

        public string CreateMessageFromRecipesList()
        {
            if(_userRecipes != null)
            {
                StringBuilder stringBuilder = new StringBuilder();

                foreach (var recipe in _userRecipes)
                {
                    stringBuilder.Append(recipe.Id);
                    stringBuilder.Append(" - ");
                    stringBuilder.Append(recipe.Name);
                    stringBuilder.Append("\n");
                }

                return stringBuilder.ToString();

            }
            else
            {
                return string.Empty;
            }
        }
    }
}
