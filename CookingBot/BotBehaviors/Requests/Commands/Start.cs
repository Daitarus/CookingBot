using CookingBot.BotBehaviors.Requests.Undefined;
using CookingBot.BotBehaviors.Responses;
using CookingBotDB.Contexts;
using CookingBotDB.Entities;
using Microsoft.Extensions.Logging;
using System.Text;

namespace CookingBot.BotBehaviors.Requests.Commands
{
    public class Start : UserRequest
    {
        public const string CommandValue = "/start";

        public Start(DbContextFactory dbContextFacoty, User user, ILogger? logger = null) : base(dbContextFacoty, user, logger)
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
            string userName = !string.IsNullOrEmpty(_user.UserName) ? _user.UserName : _user.FirstName;

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Hello ");
            stringBuilder.Append(userName);
            stringBuilder.Append("! Wellcome to bot.");

            return stringBuilder.ToString();
        }
    }
}
