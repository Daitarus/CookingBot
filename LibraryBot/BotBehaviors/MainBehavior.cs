using LibraryBot.BotBehaviors;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using LibraryBot.DataBase;

namespace LibraryBot
{
    internal static class MainBehavior
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
        private static bool ValidationOfEnteredData(string? answer)
        {
            if (!string.IsNullOrEmpty(answer))
            {
                answer = answer.ToLower();
                if (!answer.Equals("e") && !answer.Equals("exit"))
                    return true;
            }
            return false;
        }

        public static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
        {
            //TODO: write log
            //TODO: write action in DB
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                await ResponseForMessageAsync(update.Message, bot);
            }
        }
        public static async Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken)
        {
            //TODO: write log
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        private static async Task ResponseForMessageAsync(Message message, ITelegramBotClient bot)
        {
            if (!string.IsNullOrEmpty(message.Text))
            {
                LibraryBot.DataBase.User user = new LibraryBot.DataBase.User(message.From.FirstName, message.From.Id);
                switch (message.Text)
                {
                    case CommandCollection.Start:
                        {
                            await StartBehavior.ResponceForStartAsync(message.Chat, bot);
                            break;
                        }
                    case CommandCollection.PrintList:
                        {
                            await PrintListBehavior.ResponceForPrintListAsync(message.Chat, bot);
                            break;
                        }
                    case CommandCollection.Add:
                        {
                            await AddBehavior.ResponceForAddAsync(message.Chat, bot);
                            break;
                        }
                    case CommandCollection.Get:
                        {
                            await GetBehavior.ResponceForGetAsync(message.Chat, bot);
                            break;
                        }
                    default:
                        break;
                }
            }
        }        
    }
}
