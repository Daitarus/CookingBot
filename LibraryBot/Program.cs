using System.Configuration;

namespace LibraryBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string botToken = ConfigurationManager.AppSettings["BotToken"];
            TelegramBot bot = new TelegramBot(botToken);
            bot.Start(MainBehavior.HandleUpdateAsync, MainBehavior.HandleErrorAsync, MainBehavior.ConditionalStopping);
        }
    }
}