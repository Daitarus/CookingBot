using Telegram.Bot;

namespace LibraryBot
{
    public interface ITelegramBotHandles
    {
        public Task HandleUpdateAsync(ITelegramBotClient bot, Telegram.Bot.Types.Update update, CancellationToken cancellationToken);
        public Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken);
    }
}
