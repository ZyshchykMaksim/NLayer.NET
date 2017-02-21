using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.NET.BLL.Logger
{
    public interface ILogFactory
    {
        ILog<T> CreateLogger<T>() where T : class;
    }
}
