using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace LibraryBot.BotBehaviors.Responses
{
    internal interface IResponse
    {
        public Task Send(ITelegramBotClient telegramBotClient, ChatId chatId);
    }
}
