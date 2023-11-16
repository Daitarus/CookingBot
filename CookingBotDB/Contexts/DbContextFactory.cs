using Microsoft.EntityFrameworkCore;

namespace CookingBotDB.Contexts
{
    public class DbContextFactory
    {
        private DbContextOptions<MainContext> _options;

        public DbContextFactory(DbContextOptions<MainContext> options)
        {
            _options = options;
        }

        public MainContext Create()
        {
            return new MainContext(_options);
        }
    }
}
