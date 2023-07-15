using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;

namespace LibraryBot
{
    public sealed class TelegramBot
    {
        private ITelegramBotClient telegramBotClient;

        public TelegramBot(string botToken)
        {
            if (String.IsNullOrEmpty(botToken))
                throw new ArgumentNullException(nameof(botToken));

            telegramBotClient = new TelegramBotClient(botToken);
        }

        public void Start(ITelegramBotHandles telegramBotHandles, Action stopCondition)
        {
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            ReceiverOptions receiverOptions = new ReceiverOptions { AllowedUpdates = { } };
            telegramBotClient.StartReceiving(telegramBotHandles.HandleUpdateAsync, telegramBotHandles.HandleErrorAsync, receiverOptions, cancellationToken);
            stopCondition();
        }
        public ITelegramBotClient getBotClient()
        {
            return telegramBotClient;
        }
    }
}
