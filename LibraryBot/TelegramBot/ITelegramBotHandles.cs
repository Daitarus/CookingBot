using Telegram.Bot;
using Telegram.Bot.Types;

namespace LibraryBot
{
    public interface ITelegramBotHandles
    {
        public Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken);
        public Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken);
    }
}
