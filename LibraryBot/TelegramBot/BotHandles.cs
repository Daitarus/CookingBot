using LibraryBot.BotBehaviors;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LibraryBot
{
    public sealed class BotHandles : ITelegramBotHandles
    {
        private IBotBehavior botBehavior;

        public BotHandles(IBotBehavior botBehavior)
        {
            this.botBehavior = botBehavior;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            //TODO: write log
            //TODO: write action in DB
            if ((update.Type == UpdateType.Message) && (update.Message != null))
            {
                await botBehavior.RespondForMessageAsync(update.Message);
            }
        }
        public async Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
        {
            //TODO: write log
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
    }
}
