using RepositoryDB;

namespace LibraryBot.DataBase
{
    internal class RepositoryDocument : Repository<Document>
    {
        private LibraryBotDB libraryBotDB;
        public RepositoryDocument(DB db) : base(db) 
        {
            libraryBotDB = (LibraryBotDB)db;
        }
    }
}
