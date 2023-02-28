using RepositoryDB;

namespace LibraryBot.DataBase
{
    internal class Repository_User : Repository<User>
    {
        public Repository_User(DB db) : base(db) { }
    }
}
