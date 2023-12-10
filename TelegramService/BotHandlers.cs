using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramService.Interfaces;

namespace TelegramService
{
    public sealed class BotHandlers : ITelegramBotHandlers
    {
        private IBotBehavior _botBehavior;
        private ILogger? _logger;

        public BotHandlers(IBotBehavior botBehavior, ILogger? logger = null)
        {
            _botBehavior = botBehavior;
            _logger = logger;
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
