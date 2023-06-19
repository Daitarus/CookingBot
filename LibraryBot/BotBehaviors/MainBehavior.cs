using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using LibraryBot.DataBase;

namespace LibraryBot.BotBehaviors
{
    internal class MainBehavior : IBotBehavior
    {
        private Repository_Auth_Code authCodeR;
        private Repository_User userR;
        private Repository_Book bookR;

        private AuthorizationBehavior authorizationBehavior;

        public MainBehavior(ITelegramBotClient client, LibraryBotDB db)
        {
            authCodeR = new Repository_Auth_Code(db);
            userR = new Repository_User(db);
            bookR = new Repository_Book(db);

            authorizationBehavior = new AuthorizationBehavior(client);
        }

        public async Task RespondForMessageAsync(Message message)
        {
            if (message.From != null)
            {
                var user = userR.UpdateOrAddUser(new DataBase.User(message.From));

                switch (user.State)
                {
                    case (int)DataBase.User.StateOptions.Start:
                        {
                            await authorizationBehavior.RespondForAuthorization(message, user);
                            break;
                        }
                    case (int)DataBase.User.StateOptions.StartAuthorized:
                        {
                            //AnyActionBehavior();
                            break;
                        }
                    //case (int)DataBase.User.SomeActionState:
                    //    {
                    //        //SomeActionBehavior();
                    //        break;
                    //    }
                    default:
                        break;
                }
            }
        }
    }
}
