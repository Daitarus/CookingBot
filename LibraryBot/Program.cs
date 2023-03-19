using LibraryBot.DataBase;
using LibraryBot.BotBehaviors;
using System.Configuration;

namespace LibraryBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string botToken = String.Empty, connectionString = String.Empty, mainDirPath = String.Empty;
            if (ValidationOfStartData(out botToken, out connectionString, out mainDirPath))
            {
                if (LibraryBotDB.CheckDB(connectionString))
                {
                    using (LibraryBotDB db = new LibraryBotDB(connectionString))
                    {
                        TelegramBot bot = new TelegramBot(botToken);
                        MainBehavior mainBehavior = new MainBehavior(db);
                        ITelegramBotHandles telegramBotHandles = new BotHandles(mainBehavior.ResponseForMessageAsync);
                        
                        bot.Start(telegramBotHandles.HandleUpdateAsync, telegramBotHandles.HandleErrorAsync, MainServerCycle.StopCondition);
                    }
                }
                else
                    Console.WriteLine("Error: DB was not connected");
            }
            else
                Console.WriteLine("Error: Start data is empty!");
        }

        static bool ValidationOfStartData(out string botToken, out string connectionString, out string mainDirPath)
        {
            botToken = ConfigurationManager.AppSettings["BotToken"];
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            mainDirPath = ConfigurationManager.AppSettings["MainDirPath"];

            if(String.IsNullOrEmpty(botToken) || String.IsNullOrEmpty(connectionString) || String.IsNullOrEmpty(mainDirPath))
            {
                botToken = String.Empty; connectionString = String.Empty; mainDirPath = String.Empty;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}