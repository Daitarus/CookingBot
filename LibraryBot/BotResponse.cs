using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using LibraryBot.DataBase;
using LibraryBot.BotBehaviors;

namespace LibraryBot
{
    internal class BotResponse
    {
        private Repository_Auth_Code authCodeR;
        private Repository_User userR;
        private Repository_Book bookR;

        public BotResponse(LibraryBotDB db)
        {
            authCodeR = new Repository_Auth_Code(db);
            userR = new Repository_User(db);
            bookR = new Repository_Book(db);
        }

        public async Task ResponseForMessageAsync(Message message, ITelegramBotClient bot)
        {
            if (message.From != null)
            {
                var user = userR.UpdateOrAddUser(new DataBase.User(message.From));

                switch (user.State)
                {
                    case (int)DataBase.User.StateOptions.Start:
                        {
                            //authBehaivor();
                            break;
                        }
                    case (int)DataBase.User.StateOptions.StartAuthorized:
                        {
                            //AnyActionBehaivor();
                            break;
                        }
                    //case (int)DataBase.User.SomeActionState:
                    //    {
                    //        //SomeActionBehaivor();
                    //        break;
                    //    }
                    default:
                        break;
                }
            }
        }
    }
}
