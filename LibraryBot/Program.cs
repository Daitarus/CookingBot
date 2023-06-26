﻿using LibraryBot.DataBase;
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
                string mainDirPath = configValues.GetValueForKey("MainDirPath").GetValue();

                string createDBScript = LibraryBotDB.GetSqlScript(sqlScriptPath);
                //TODO: add connection with script

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
                    Console.WriteLine("Error: The DB was not connected");
            }
            else
                Console.WriteLine("Error: The data in the config file is empty!");
        }
    }
}