using Telegram.Bot;

namespace LibraryBot
{
    public interface ITelegramBotHandles
    {
        public Task HandleUpdateAsync(ITelegramBotClient client, Telegram.Bot.Types.Update update, CancellationToken cancellationToken);
        public Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken);
    }
}
