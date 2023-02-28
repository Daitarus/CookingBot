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
                TelegramBot bot = new TelegramBot(botToken);
                Console.WriteLine("Bot was started...");
                bot.Start(MainBehavior.HandleUpdateAsync, MainBehavior.HandleErrorAsync, MainBehavior.ConditionalStopping);
            }
            else
            {
                Console.WriteLine("Error: Start data is empty!");
            }
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