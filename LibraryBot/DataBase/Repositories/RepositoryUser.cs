using RepositoryDB;

namespace LibraryBot.DataBase
{
    internal class RepositoryUser : Repository<User>
    {
        private LibraryBotDB libraryBotDB;
        public RepositoryUser(RepositoryDB.DataBase db) : base(db) 
        {
            libraryBotDB = (LibraryBotDB)db;
        }

        public User? SelectForTelegramId(long TelegramId)
        {
            IQueryable<User> users = libraryBotDB.Users.Where(user => user.IdTelegram.Equals(TelegramId));
            if (users.Count() > 0)
            {
                return users.First();
            }
            return null;
        }

        public void UpdateOrAddForTelegramId(User user)
        {
            User? oldUser = SelectForTelegramId(user.IdTelegram);
            if(oldUser == null)
            {
                Add(user);
            }
            else
            {
                if(!oldUser.Equals(user))
                {
                    oldUser.Update(user);
                }
            }
        }
    }
}
