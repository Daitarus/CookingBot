using RepositoryDB;

namespace LibraryBot.DataBase
{
    internal class Repository_Book : Repository<Book>
    {
        public Repository_Book(DB db) : base(db) { }
    }
}
