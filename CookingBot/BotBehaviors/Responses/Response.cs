using Telegram.Bot;
using Telegram.Bot.Types;

namespace CookingBot.BotBehaviors.Responses
{
    public class Response : IResponse
    {
        public string? Text { get; }
        public InputFile? File { get; }

        public Response(string? text = null, InputFile? file = null)
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
