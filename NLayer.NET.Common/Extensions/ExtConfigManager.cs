using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.NET.Common.Extensions
{
    public static class ExtConfigManager
    {
        public static T GetValue<T>(this NameValueCollection nameValuePairs, string configKey, T defaultValue) where T : IConvertible
        {
            T retVal = default(T);
            if (nameValuePairs.AllKeys.Contains(configKey))
            {
                string tmpValue = nameValuePairs[configKey];
                retVal = (T)Convert.ChangeType(tmpValue, typeof(T));
            }
            else
                return defaultValue;

            return retVal;
        }
    }
}
