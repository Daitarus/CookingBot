using Telegram.Bot.Types;

namespace CookingBot.BotBehaviors.Requests.Interfaces
{
    internal interface IRequestFactory
    {
        public IRequest Create(Message message, CookingBotDB.Entities.User? user);
    }
}
