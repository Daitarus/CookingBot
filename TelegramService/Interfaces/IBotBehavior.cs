using Telegram.Bot.Types;

namespace TelegramService.Interfaces
{
    public interface IBotBehavior
    {
        public Task RespondForMessageAsync(Message message);
    }
}
