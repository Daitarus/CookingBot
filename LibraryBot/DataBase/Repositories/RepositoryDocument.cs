using RepositoryDB;

namespace LibraryBot.DataBase
{
    internal class RepositoryDocument : Repository<Document>
    {
        private LibraryBotDB libraryBotDB;
        public RepositoryDocument(RepositoryDB.DataBase db) : base(db) 
        {
            libraryBotDB = (LibraryBotDB)db;
        }
    }
}
