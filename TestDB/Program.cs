using CookingBotDB;
using CookingBotDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionStringPostgre = "Server = localhost; Port=5432; Database = CookingBot; UserId = cookingBot; Password = cookingBot";
            string connectionStringMSSQL = "server = localhost; database = CookingBot; user = cookingBot; password = cookingBot; TrustServerCertificate=True";

            var contextOptions = DbContextOptionFactory.Create(connectionStringPostgre, DbType.PostgreSQL, TimeSpan.FromSeconds(30));
            var contextFactory = new DbContextFactory(contextOptions);

            WorkingWithDB(contextFactory);
        }

        static void WorkingWithDB(DbContextFactory contextFactory)
        {
            var user = new SimpleUser()
            {
                Name = "TestUser"
            };

            var recipe = new SimpleRecipe()
            {
                Name = "TestRecipe",
                User = user,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
                Text = "This is the simple recipe"
            };

            using (var context = contextFactory.Create())
            {
                context.Database.EnsureCreated();
            }

            using (var context = contextFactory.Create())
            {
                context.Add(user);
                context.Add(recipe);

                context.SaveChanges();
            }
        }
    }
}