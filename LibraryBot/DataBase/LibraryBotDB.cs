using Microsoft.EntityFrameworkCore;
using RepositoryDB;

namespace LibraryBot.DataBase
{
    internal class LibraryBotDB : DB
    {
        public LibraryBotDB(string connectionString) : base(connectionString) { }

        public DbSet<Auth_Code> Auth_Codes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
