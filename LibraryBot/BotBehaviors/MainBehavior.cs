using LibraryBot.BotBehaviors;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using LibraryBot.DataBase;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LibraryBot
{
    internal class MainBehavior
    {
        private Repository_Auth_Code authCodeR;
        private Repository_User userR;
        private Repository_Book bookR;

        public MainBehavior(LibraryBotDB db) 
        {
            authCodeR = new Repository_Auth_Code(db);
            userR = new Repository_User(db);
            bookR = new Repository_Book(db);
        }

        public static void ConditionalStopping()
        {
            Console.WriteLine("Bot was started...");
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

        public async Task HandleUpdateAsync(ITelegramBotClient bot, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
        {
            //TODO: write log
            //TODO: write action in DB
            if ((update.Type == Telegram.Bot.Types.Enums.UpdateType.Message) && (update.Message != null))
            {
                await ResponseForMessageAsync(update.Message, bot);
            }
        }
        public async Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken)
        {
            //TODO: write log
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        private async Task ResponseForMessageAsync(Message message, ITelegramBotClient bot)
        {
            if (message.From != null)
            {
                var user = UpdateUserFromDB(new LibraryBot.DataBase.User(message.From));

                if (!String.IsNullOrEmpty(message.Text))
                {
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
        
        private LibraryBot.DataBase.User UpdateUserFromDB(LibraryBot.DataBase.User newUser)
        {
            var oldUser = userR.GetForTelegramId(newUser.IdTelegram);
            if (oldUser == null)
            {
                userR.Add(newUser);
                userR.SaveChange();
                return newUser;
            }
            else
            {
                if(!oldUser.EqualsForMainArgs(newUser))
                {
                    oldUser.UpdateMainArgs(newUser);
                    userR.SaveChange();
                }
                return oldUser;
            }
        }
    }
}
