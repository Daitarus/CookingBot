using CookingBot.DataBase.Entities;
using RepositoryDB;

namespace LibraryBot.DataBase
{
    internal class UserRepository : Repository<User>
    {
        private CookingBotDB libraryBotDB;
        public UserRepository(RepositoryDB.DataBase db) : base(db) 
        {
            libraryBotDB = (CookingBotDB)db;
        }

        public User? SelectForIdTelegram(long IdTelegram)
        {
            IQueryable<User> users = libraryBotDB.Users.Where(user => user.IdTelegram.Equals(IdTelegram));
            if (users.Count() > 0)
            {
                return users.First();
            }
            return null;
        }

        public void UpdateOrAddForTelegramId(User user)
        {
            User? oldUser = SelectForIdTelegram(user.IdTelegram);
            if(oldUser == null)
            {
                Add(user);
            }
            else
            {
                if(!oldUser.Equals(user))
                {
                    oldUser.UpdateMainProperties(user);
                }
            }
        }
    }
}
