using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CookingBotDB.Contexts
{
    public static class DbContextOptionFactory
    {
        public static DbContextOptions<MainContext> Create(DbInitOption dbInitOption, TimeSpan commandTimeout, ILogger? logger = null)
        {
            return Create(dbInitOption.ConnectionString, dbInitOption.DbType, commandTimeout, logger);
        }
        public static DbContextOptions<MainContext> Create(string connectionString, DatabaseType dbType, TimeSpan commandTimeout, ILogger? logger = null)
        {
            var dbContextOptionBuilder = new DbContextOptionsBuilder<MainContext>();

            switch (dbType)
            {
                case DatabaseType.MSSQL:
                    dbContextOptionBuilder.UseSqlServer(connectionString,
                        optionsBuilder => optionsBuilder
                                .CommandTimeout((int)commandTimeout.TotalSeconds)
                                //.MigrationsAssembly("MigrationsSqlServer")
                                .EnableRetryOnFailure()
                        );
                    break;
                case DatabaseType.PostgreSQL:
                    dbContextOptionBuilder.UseNpgsql(connectionString,
                        optionsBuilder => optionsBuilder
                                .CommandTimeout((int)commandTimeout.TotalSeconds)
                                //.MigrationsAssembly("MigrationsPostgres")
                                .EnableRetryOnFailure()
                        );
                    break;
            }

            if (logger != null)
            {
                dbContextOptionBuilder.UseLoggerFactory(LoggerFactory.Create(builder =>
                {
                    builder.AddProvider(new DBLoggerProvider(logger));
                }));
            }

            return dbContextOptionBuilder.Options;
        }
    }
}
