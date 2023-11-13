using RepositoryDB;

namespace LibraryBot.DataBase
{
    internal class DocumentRepository : Repository<Document>
    {
        private CookingBotDB libraryBotDB;
        public DocumentRepository(RepositoryDB.DataBase db) : base(db) 
        {
            libraryBotDB = (CookingBotDB)db;
        }
    }
}
