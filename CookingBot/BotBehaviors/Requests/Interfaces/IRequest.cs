using CookingBot.BotBehaviors.Responses;

namespace CookingBot.BotBehaviors.Requests.Interfaces
{
    public interface IRequest
    {
        public bool TryExecute();
        public IResponse CreateResponse();
    }
}
