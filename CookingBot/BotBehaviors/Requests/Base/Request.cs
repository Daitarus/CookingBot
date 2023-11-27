using CookingBot.BotBehaviors.Requests.Interfaces;
using CookingBot.BotBehaviors.Responses;

namespace CookingBot.BotBehaviors.Requests.Base
{
    public class Request : IRequest
    {
        public virtual void Execute() { }

        public virtual IResponse CreateResponse()
        {
            return new Response("Sorry, but this request is not defined.");
        }
    }
}
