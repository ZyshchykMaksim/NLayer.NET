using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.NET.BLL.Logger
{
    public interface ILog<T> where T : class
    {
        void Trace(string message);
        void Trace(string message, params object[] args);
        void Trace(string message, Exception exception);
        void Debug(string message);
        void Debug(string message, params object[] args);
        void Debug(string message, Exception exception);
        void Info(string message);
        void Info(string message, params object[] args);
        void Info(string message, Exception exception);
        void Warn(string message);
        void Warn(string message, params object[] args);
        void Warn(string message, Exception exception);
        void Error(string message);
        void Error(string message, params object[] args);
        void Error(string message, Exception exception);
        void Fatal(string message);
        void Fatal(string message, params object[] args);
        void Fatal(string message, Exception exception);
    }
}
