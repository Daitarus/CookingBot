using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramService.Interfaces
{
    public interface ITelegramBotHandlers
    {
        public Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken);
        public Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken);
    }
}
