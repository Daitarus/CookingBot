using CookingBotDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookingBotDB.Contexts
{
    public class MainContext : DbContext
    {
        public DbSet<ArgumentMessage> ArgumentMessage { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {

        }
    }
}
