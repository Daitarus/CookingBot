

using CookingBotDB.Contexts;

namespace CookingBot.Settings
{
    public class Appsetting
    {
        public const string AppsettingName = "Appsetting";
        public string BotToken {  get; set; }
        public DbInitOption DbInitOption {  get; set; }
        public TimeSpan CommanTimeout { get; set; }
    }
}
