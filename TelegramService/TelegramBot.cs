using Telegram.Bot;
using Telegram.Bot.Polling;
using TelegramService.Interfaces;

namespace TelegramService
{
    public sealed class TelegramBot
    {
        public ITelegramBotClient TelegramBotClient { get; }

        public TelegramBot(string botToken)
        {
            if (string.IsNullOrEmpty(botToken))
                throw new ArgumentNullException(nameof(botToken));

            TelegramBotClient = new TelegramBotClient(botToken);
        }

        public void Start(ITelegramBotHandlers telegramBotHandles, Action stopCondition)
        {
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            ReceiverOptions receiverOptions = new ReceiverOptions { AllowedUpdates = { } };
            TelegramBotClient.StartReceiving(telegramBotHandles.HandleUpdateAsync, telegramBotHandles.HandleErrorAsync, receiverOptions, cancellationToken);
            stopCondition();
        }
    }
}
