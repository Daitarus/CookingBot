using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CookingBotDB.Contexts
{
    public class DbInitOption
    {
        public string ConnectionString { get; set; } = string.Empty;

        [JsonConverter(typeof(StringEnumConverter))]
        public DatabaseType DbType { get; set; } = DatabaseType.MSSQL;

        public bool Logging { get; set; } = false;
    }
}
