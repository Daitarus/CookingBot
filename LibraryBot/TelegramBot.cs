using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using System.Diagnostics;

namespace LibraryBot
{
    internal sealed class TelegramBot
    {
        private ITelegramBotClient client;

        public TelegramBot(string botToken)
        {
            if (String.IsNullOrEmpty(botToken))
                throw new ArgumentNullException(nameof(botToken));

            client = new TelegramBotClient(botToken);
        }

        public void Start(Func<ITelegramBotClient, Update, CancellationToken, Task> handleUpdateAsync, Func<ITelegramBotClient, Exception, CancellationToken, Task> handleErrorAsync, Action conditionalStopping)
        {
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            ReceiverOptions receiverOptions = new ReceiverOptions{AllowedUpdates = { }};
            client.StartReceiving(handleUpdateAsync, handleErrorAsync, receiverOptions, cancellationToken);
            conditionalStopping();
        }
    }
}
