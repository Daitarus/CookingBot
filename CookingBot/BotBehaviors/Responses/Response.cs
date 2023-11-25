using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace CookingBot.BotBehaviors.Responses
{
    public class Response : IResponse
    {
        public string? Text { get; }
        public InputOnlineFile? File { get; }

        public Response(string? text = null, InputOnlineFile? file = null)
        {
            Text = text;
            File = file;
        }

        public async Task Send(ITelegramBotClient telegramBotClient, ChatId chatId)
        {
            if (Text != null)
                await telegramBotClient.SendTextMessageAsync(chatId, Text);
            if (File != null)
                await telegramBotClient.SendDocumentAsync(chatId, File);
        }
    }
}
