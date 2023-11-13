using CookingBot.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryDB;

namespace LibraryBot.DataBase
{
    internal class CookingBotDB : RepositoryDB.DataBase
    {
        public CookingBotDB(string connectionString) : base(connectionString) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Document> Books { get; set; }
    }
}
