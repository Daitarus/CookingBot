using RepositoryDB;

namespace LibraryBot.DataBase
{
    internal class Repository_User : Repository<User>
    {
        private LibraryBotDB libraryBotDB;
        public Repository_User(DB db) : base(db) 
        {
            libraryBotDB = (LibraryBotDB)db;
        }

        public User? GetForTelegramId(long IdTelegram)
        {
            IQueryable<User> users = libraryBotDB.Users.Where(user => user.IdTelegram.Equals(IdTelegram));
            if (users.Count() > 0)
            {
                return users.First();
            }
            return null;
        }
    }
}
