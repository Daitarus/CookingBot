using LibraryBot.DataBase;
using LibraryBot.BotBehaviors;
using ConfigHandler;

namespace LibraryBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigValues configValues = new ConfigValues("BotToken", "ConnectionString", "MainDirPath");
            if (configValues.IsAllValuesNotEmpty())
            {
                string botToken = configValues.GetValueForKey("BotToken").GetValue();
                string connectionString = configValues.GetValueForKey("ConnectionString").GetValue();
                string mainDirPath = configValues.GetValueForKey("MainDirPath").GetValue();

                if (LibraryBotDB.CheckDB(connectionString))
                {
                    using (LibraryBotDB db = new LibraryBotDB(connectionString))
                    {
                        TelegramBot bot = new TelegramBot(botToken);
                        IBotBehavior mainBehavior = new MainBehavior(bot.getClient(), db);
                        ITelegramBotHandles telegramBotHandles = new BotHandles(mainBehavior);
                        
                        bot.Start(telegramBotHandles.HandleUpdateAsync, telegramBotHandles.HandleErrorAsync, MainServerCycle.StopCondition);
                    }
                }
                else
                    Console.WriteLine("Error: DB was not connected");
            }
            else
                Console.WriteLine("Error: Start data is empty!");
        }
    }
}