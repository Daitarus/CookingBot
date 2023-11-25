using CookingBot.BotBehaviors.Responses;

namespace CookingBot.BotBehaviors.Requests.Interfaces
{
    public interface IRequest
    {
        public void Execute();
        public IResponse CreateResponse();
    }
}
