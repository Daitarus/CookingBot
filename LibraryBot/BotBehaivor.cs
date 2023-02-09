using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;

namespace LibraryBot
{
    public static class BotBehaivor
    {
        public static void ConditionalStopping()
        {
            string answer = String.Empty;
            do
            {
                Console.WriteLine("If you want stopped bot, enter \'exit\' or \'e\'");
                answer = Console.ReadLine();
            } while (ValidationOfEnteredData(answer));
        }
        private static bool ValidationOfEnteredData(string answer)
        {
            if (!String.IsNullOrEmpty(answer))
                answer = answer.ToLower();
            if (!answer.Equals("e") && !answer.Equals("exit"))
                return true;
            else
                return false;
        }


        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                Message message = update.Message;
                string response = GetResponseForMessage(message);
                if (!String.IsNullOrEmpty(response))
                {
                    await botClient.SendTextMessageAsync(message.Chat, response);
                }
            }
        }
        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        private static string GetResponseForMessage(Message message)
        {
            string messageText = message.Text;
            if (!String.IsNullOrEmpty(messageText))
            {
                switch (messageText)
                {
                    case "/start":
                        {
                            return "Welcome back!!!";
                        }
                    default:
                        {
                            return "Ok";
                        }
                }
            }
            return String.Empty;
        }
    }
}
