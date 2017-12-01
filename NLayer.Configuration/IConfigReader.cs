using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Configuration
{
    public interface IConfigReader
    {
        T GetConfigValue<T>(string key, T defaultValue = default(T));
    }
}
