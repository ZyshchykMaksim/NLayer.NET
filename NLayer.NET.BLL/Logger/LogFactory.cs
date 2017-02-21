using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.NET.BLL.Logger
{
    public class LogFactory : ILogFactory
    {
        public ILog<T> CreateLogger<T>() where T : class
        {
            return new Log<T>();
        }
    }
}
