using RepositoryDB;

namespace LibraryBot.DataBase
{
    internal class Repository_User : Repository<User>
    {
        public Repository_User(DB db) : base(db) { }

        public User? SelectForIdTelegram(long idTelegram)
        {
            LibraryBotDB libraryBotDB = (LibraryBotDB)db;
            IQueryable<User> users = libraryBotDB.Users.Where(user => user.IdTelegram.Equals(idTelegram));
            if (users.Count() > 0)
            {
                return users.First();
            }
            return null;
        }
    }
}
