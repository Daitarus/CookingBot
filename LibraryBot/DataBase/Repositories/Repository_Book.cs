using RepositoryDB;

namespace LibraryBot.DataBase
{
    internal class Repository_Book : Repository<Book>
    {
        private LibraryBotDB libraryBotDB;
        public Repository_Book(DB db) : base(db) 
        {
            libraryBotDB = (LibraryBotDB)db;
        }
    }
}
