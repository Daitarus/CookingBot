using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors
{
    public interface IBotBehavior
    {
        public Task RespondForMessageAsync(Message message);
    }
}
