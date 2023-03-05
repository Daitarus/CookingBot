using RepositoryDB;
using System.Security.AccessControl;

namespace LibraryBot.DataBase
{
    internal class Repository_Auth_Code : Repository<Auth_Code>
    {
        private LibraryBotDB libraryBotDB;
        public Repository_Auth_Code(DB db) : base(db) 
        {
            libraryBotDB = (LibraryBotDB)db;
        }

        public Auth_Code? SelectForCode(string code)
        {
            IQueryable<Auth_Code> auth_codes = libraryBotDB.Auth_Codes.Where(auth_code => auth_code.Code.Equals(code));
            if (auth_codes.Count() > 0)
            {
                return auth_codes.First();
            }
            return null;
        }
    }
}
