using RepositoryDB;

namespace RepositoryLibraryBot.DataBase
{
    public class LibraryBotDB : DB
    {
        public LibraryBotDB(string connectionString) : base(connectionString) { }

        //TODO: Add DBSet for entities
        //public DbSet<Client> Clients { get; set; }
    }
}
