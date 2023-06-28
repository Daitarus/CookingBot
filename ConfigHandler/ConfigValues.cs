using System.Configuration;

namespace ConfigHandler
{
    public class ConfigValues
    {
        private readonly ConfigValue[] values;
        public int Length { get; }

        public ConfigValues(params string[] keys)
        {
            values = new ConfigValue[keys.Length];
            for(int i = 0; i < keys.Length; i++)
            {
                values[i] = new ConfigValue(keys[i]);
            }
            Length = values.Length;
        }

        public bool IsAllValuesNotEmpty()
        {
            foreach (var value in values)
            {
                if(value.IsValueEmpty())
                {
                    return false;
                }
            }
            return true;
        }

        public int[] WhatValueIsEmpty()
        {
            List<int> indicesOfValue = new List<int>();
            for (int i = 0; i < indicesOfValue.Count; i++)
            {
                if(values[i].IsValueEmpty())
                    indicesOfValue.Add(i);
            }
            return indicesOfValue.ToArray();
        }

        public ConfigValue[] GetValues()
        {
            return values;
        }

        public ConfigValue GetValueForIndex(int index)
        {
            if (index >= 0 && index < values.Length)
                return values[index];
            else
                throw new ArgumentException($"{nameof(ConfigValue)} for this index not found", nameof(index));
        }
        public ConfigValue GetValueForKey(string key)
        {
            foreach(var value in values)
            {
                if(value.key.Equals(key))
                {
                    return value;
                }
            }

            throw new ArgumentException($"{nameof(ConfigValue)} for this key not found", nameof(key));
        }
    }
}
