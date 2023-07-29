using RepositoryDB;

namespace LibraryBot.DataBase
{
    internal class DocumentRepository : Repository<Document>
    {
        private LibraryBotDB libraryBotDB;
        public DocumentRepository(RepositoryDB.DataBase db) : base(db) 
        {
            libraryBotDB = (LibraryBotDB)db;
        }
    }
}
