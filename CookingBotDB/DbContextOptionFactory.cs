using Microsoft.EntityFrameworkCore;

namespace CookingBotDB
{
    public static class DbContextOptionFactory
    {
        public static DbContextOptions<MainContext> Create(string connectionString, DbType dbType, TimeSpan commandTimeout)
        {
            var dbContextOptionBuilder = new DbContextOptionsBuilder<MainContext>();

            switch (dbType)
            {
                case DbType.MSSQL:
                    dbContextOptionBuilder.UseSqlServer(connectionString,
                        optionsBuilder => optionsBuilder
                                .CommandTimeout((int)commandTimeout.TotalSeconds)
                                //.MigrationsAssembly("MigrationsSqlServer")
                                .EnableRetryOnFailure()
                        );
                    break;
                case DbType.PostgreSQL:
                    dbContextOptionBuilder.UseNpgsql(connectionString,
                        optionsBuilder => optionsBuilder
                                .CommandTimeout((int)commandTimeout.TotalSeconds)
                                //.MigrationsAssembly("MigrationsPostgres")
                                .EnableRetryOnFailure()
                        );
                    break;
            }

            return dbContextOptionBuilder.Options;
        }
    }
}
