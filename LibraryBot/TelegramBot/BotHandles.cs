using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace LibraryBot
{
    public sealed class BotHandles : ITelegramBotHandles
    {
        private Func<Message, ITelegramBotClient, Task> responseForMessageAsync;

        public BotHandles(Func<Message, ITelegramBotClient, Task> responseForMessageAsync)
        {
            this.responseForMessageAsync = responseForMessageAsync;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
        {
            //TODO: write log
            //TODO: write action in DB
            if ((update.Type == UpdateType.Message) && (update.Message != null))
            {
                await responseForMessageAsync(update.Message, bot);
            }
        }
        public async Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken)
        {
            //TODO: write log
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
    }
}
