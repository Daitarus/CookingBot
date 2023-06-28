using Microsoft.EntityFrameworkCore;
using System.Text;

namespace RepositoryDB
{
    public class DB : DbContext
    {
        public readonly string connectionString;

        public DB(string connectionString)
        {
            if(String.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            this.connectionString = connectionString;
            Database.EnsureCreated();
        }
        public DB(string connectionString, string script)
        {

            if (String.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            this.connectionString = connectionString;
            if (Database.EnsureCreated())
            {
                Database.ExecuteSqlRaw(script);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }

        public static bool CheckDB(string connectionString)
        {
            try
            {
                using (new DB(connectionString)) { }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckDB(string connectionString, string script)
        {
            try
            {
                using (new DB(connectionString, script)) { }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string GetSqlScript(string fileText)
        {
            string sqlScript = String.Empty;

            if (!String.IsNullOrEmpty(fileText))
            {
                FileInfo fileInfo = new FileInfo(fileText);
                if (fileInfo.Exists)
                {
                    byte[] sqlScriptBytes = new byte[fileInfo.Length];
                    using (FileStream fstream = System.IO.File.Open(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        fstream.Read(sqlScriptBytes);
                    }
                    sqlScript = Encoding.UTF8.GetString(sqlScriptBytes);
                }
            }

            return sqlScript;
        }
    }
}
