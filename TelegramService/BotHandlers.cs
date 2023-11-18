using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramService.Interfaces;

namespace TelegramService
{
    public sealed class BotHandlers : ITelegramBotHandlers
    {
        private IBotBehavior _botBehavior;

        public BotHandlers(IBotBehavior botBehavior)
        {
            _botBehavior = botBehavior;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            //TODO: write log
            //TODO: write action in DB
            if ((update.Type == UpdateType.Message) && (update.Message != null))
            {
                await _botBehavior.RespondForMessageAsync(update.Message);
            }
        }
        public async Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
        {
            //TODO: write log
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
    }
}
