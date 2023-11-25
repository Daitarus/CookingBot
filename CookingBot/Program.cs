using CookingBot.BotBehaviors;
using Microsoft.Extensions.Configuration;
using CookingBot.Settings;
using CookingBotDB.Contexts;

namespace CookingBot
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = GetConfiguration();
            var appsetting = config.Get<Appsetting>();

            var dbContextOption = DbContextOptionFactory.Create(appsetting.DbInitOption, appsetting.CommanTimeout);
            var dbContextFactory = new DbContextFactory(dbContextOption);

            TelegramBot bot = new TelegramBot(botToken);

            IBotBehavior mainBehavior = new BotBehavior(bot.getBotClient(), db, mainDirectoryInfo);
            ITelegramBotHandles telegramBotHandles = new BotHandles(mainBehavior);

            bot.Start(telegramBotHandles, MainServerCycle.StopCondition);
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