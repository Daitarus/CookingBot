using Telegram.Bot;
using Telegram.Bot.Types;

namespace CookingBot.BotBehaviors.Responses
{
    public interface IResponse
    {
        public Task Send(ITelegramBotClient telegramBotClient, ChatId chatId);
    }
}
