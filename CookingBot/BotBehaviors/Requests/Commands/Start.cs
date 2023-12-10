using CookingBot.BotBehaviors.Requests.Interfaces;
using CookingBot.BotBehaviors.Responses;
using CookingBotDB.Contexts;
using CookingBotDB.Entities;
using System.Text;

namespace CookingBot.BotBehaviors.Requests.Commands
{
    internal class Start : IRequest
    {
        public const string CommandValue = "/start";

        private const UserState _assignableUserState = UserState.Initial;

        private DbContextFactory _dbContextFacoty;
        private User _user;

        public Start(DbContextFactory dbContextFacoty, User user)
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
            string userName = !string.IsNullOrEmpty(_user.UserName) ? _user.UserName : _user.FirstName;

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Hello ");
            stringBuilder.Append(userName);
            stringBuilder.Append("! Wellcome to bot.");

            return stringBuilder.ToString();
        }
    }
}
