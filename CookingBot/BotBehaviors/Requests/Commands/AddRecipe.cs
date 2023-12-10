using CookingBot.BotBehaviors.Responses;
using System.Text;
using CookingBot.BotBehaviors.Requests.Interfaces;
using CookingBotDB.Entities;
using CookingBotDB.Contexts;

namespace CookingBot.BotBehaviors.Requests.Commands
{
    internal class AddRecipe : IRequest
    {
        public const string CommandValue = "/add_recipe";

        private const UserState _assignableUserState = UserState.AddRecipe;

        private DbContextFactory _dbContextFacoty;
        private User _user;

        public AddRecipe(DbContextFactory dbContextFacoty, User user)
        {
            if (dbContextFacoty == null)
                throw new ArgumentNullException(nameof(dbContextFacoty));
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _dbContextFacoty = dbContextFacoty;
            _user = user;
        }

        public void Execute()
        {
            _user.State = _assignableUserState;

            using (var context = _dbContextFacoty.Create())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == _user.Id);
                user = _user;
                context.SaveChanges();
            }
        }

        public IResponse CreateResponse()
        {
            return new Response(CreateResponseText());
        }

        //TODO Get ResponseText from file
        private string CreateResponseText()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Отправте имя рецепта и сам рецепт текстом с следующий строки или текстовым файлом.\n");

            return stringBuilder.ToString();
        }
    }
}
