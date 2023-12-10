using CookingBot.BotBehaviors;
using Microsoft.Extensions.Configuration;
using CookingBot.Settings;
using CookingBotDB.Contexts;
using TelegramService;
using TelegramService.Interfaces;

namespace CookingBot
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = GetConfiguration();
            var appsetting = config.Get<Appsetting>();
            if(appsetting == null) throw new NullReferenceException(nameof(appsetting));

            var dbContextOption = DbContextOptionFactory.Create(appsetting.DbInitOption, appsetting.CommanTimeout);
            var dbContextFactory = new DbContextFactory(dbContextOption);

            TelegramBot bot = new TelegramBot(appsetting.BotToken);

            IBotBehavior mainBehavior = new BotBehavior(bot.TelegramBotClient, dbContextFactory);
            ITelegramBotHandlers telegramBotHandles = new BotHandlers(mainBehavior);

            bot.Start(telegramBotHandles, MainServerCycle.StopCondition);
        }

        private static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
              .AddJsonFile("appsetting.dev", true)
              .AddJsonFile("appsetting.json")
              .Build();
        }
    }
}