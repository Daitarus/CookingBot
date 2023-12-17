using CookingBot.BotBehaviors.Requests.Interfaces;
using CookingBot.BotBehaviors.Responses;

namespace CookingBot.BotBehaviors.Requests.Undefined
{
    public class Request : IRequest
    {
        protected bool _isExecuted = false;

        public virtual void Execute() 
        {
            _isExecuted = true;
        }

        //TODO Get ResponseText from file
        public virtual IResponse CreateResponse()
        {
            if (_isExecuted)
            {
                return new Response("Sorry, but this request is not defined.");
            }
            else
            {
                return new Response("Sorry, but this request is not executed.");
            }
        }
    }
}
