using System.ComponentModel;
using System.Configuration;

namespace NLayer.Configuration
{
    public class ConfigReader : IConfigReader
    {
        #region Implementation of IConfigReader

        public T GetConfigValue<T>(string key, T defaultValue = default(T))
        {

            string value = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            return (T)converter.ConvertFromString(value);
        }

        #endregion
    }
}
