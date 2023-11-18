using LibraryBot.DataBase;
using LibraryBot.BotBehaviors;
using ConfigHandler;
using Microsoft.Extensions.Configuration;
using CookingBot.Settings;

namespace LibraryBot
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = GetConfiguration();
            var appsetting = config.Get<Appsetting>();

            DirectoryInfo mainDirectoryInfo = new DirectoryInfo(configValues.GetValueForKey("MainDirPath").GetValue());

            string createTablesScript = LibraryBot.DataBase.CookingBotDB.GetSqlScript(sqlScriptPath);
            using (var db = new LibraryBot.DataBase.CookingBotDB(connectionString))
            {
                TelegramBot bot = new TelegramBot(botToken);

                IBotBehavior mainBehavior = new BotBehavior(bot.getBotClient(), db, mainDirectoryInfo);
                ITelegramBotHandles telegramBotHandles = new BotHandles(mainBehavior);

                bot.Start(telegramBotHandles, MainServerCycle.StopCondition);
            }
        }

        private static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
              .AddJsonFile("appsettings.dev", true)
              .AddJsonFile("appsettings.json")
              .Build();
        }
    }
}