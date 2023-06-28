using System.Configuration;

namespace ConfigHandler
{
    public class ConfigValue
    {
        public readonly string key;
        public readonly string value;

        public ConfigValue(string key)
        {
            this.key = key;
            value = ConfigurationManager.AppSettings[key];

            if(value == null)
            {
                value = String.Empty;
            }
        }

        public bool IsValueEmpty()
        {
            if (value.Equals(String.Empty))
                return true;
            else
                return false;
        }

        public string GetKey()
        {
            return key;
        }
        public string GetValue()
        {
            return value;
        }
    }
}