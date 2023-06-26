using Microsoft.EntityFrameworkCore;
using RepositoryDB;

namespace LibraryBot.DataBase
{
    internal class LibraryBotDB : DB
    {
        public LibraryBotDB(string connectionString) : base(connectionString) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Document> Books { get; set; }
    }
}
