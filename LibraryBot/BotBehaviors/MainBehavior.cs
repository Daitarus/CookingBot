using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using LibraryBot.DataBase;

namespace LibraryBot.BotBehaviors
{
    internal class MainBehavior : IBotBehavior
    {
        private RepositoryUser userR;
        private RepositoryDocument bookR;

        private AuthorizationBehavior authorizationBehavior;

        public MainBehavior(ITelegramBotClient client, LibraryBotDB db)
        {
            userR = new RepositoryUser(db);
            bookR = new RepositoryDocument(db);

            authorizationBehavior = new AuthorizationBehavior(client);
        }

        public async Task RespondForMessageAsync(Message message)
        {
            if (message.From != null)
            {
                var user = userR.UpdateOrAddUser(new DataBase.User(message.From));

                //switch (user.State)
                //{
                //    case (int)DataBase.User.StateOptions.Start:
                //        {
                //            await authorizationBehavior.RespondForAuthorization(message, user);
                //            break;
                //        }
                //    case (int)DataBase.User.StateOptions.StartAuthorized:
                //        {
                //            //AnyActionBehavior();
                //            break;
                //        }
                //    //case (int)DataBase.User.SomeActionState:
                //    //    {
                //    //        //SomeActionBehavior();
                //    //        break;
                //    //    }
                //    default:
                //        break;
                //}
            }
        }
    }
}
