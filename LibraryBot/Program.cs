using LibraryBot.DataBase;
using LibraryBot.BotBehaviors;
using ConfigHandler;

namespace LibraryBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigValues configValues = new ConfigValues("BotToken", "ConnectionString", "SQLScriptPath", "MainDirPath");
            if (configValues.IsAllValuesNotEmpty())
            {
                string botToken = configValues.GetValueForKey("BotToken").GetValue();
                string connectionString = configValues.GetValueForKey("ConnectionString").GetValue();
                string sqlScriptPath = configValues.GetValueForKey("SQLScriptPath").GetValue();
                DirectoryInfo mainDirectoryInfo = new DirectoryInfo(configValues.GetValueForKey("MainDirPath").GetValue());

                string createTablesScript = LibraryBotDB.GetSqlScript(sqlScriptPath);
                if(LibraryBotDB.CheckOrCreateDB(connectionString, createTablesScript))
                {
                    using (LibraryBotDB db = new LibraryBotDB(connectionString))
                    {
                        TelegramBot bot = new TelegramBot(botToken);

                        IBotBehavior mainBehavior = new BotBehavior(bot.getBotClient(), db, mainDirectoryInfo);
                        ITelegramBotHandles telegramBotHandles = new BotHandles(mainBehavior);

                        bot.Start(telegramBotHandles, MainServerCycle.StopCondition);
                    }
                }
                else
                    Console.WriteLine("Error: The DB was not created!");
            }
            else
                Console.WriteLine("Error: The data in the config file is empty!");
        }
    }
}