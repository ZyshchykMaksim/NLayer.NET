using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace NLayer.NET.BLL.Logger
{
    public class Log<T> : ILog<T> where T : class
    {
        private readonly NLog.Logger _logger;

        public Log()
        {
            _logger = LogManager.GetLogger(typeof(T).FullName);
        }

        public void Trace(string message)
        {
            _logger.Log(LogLevel.Trace, message);
        }

        public void Trace(string message, params object[] args)
        {
            _logger.Log(LogLevel.Trace, message, args);
        }

        public void Trace(string message, Exception exception)
        {
            _logger.Log(LogLevel.Trace, exception, message);
        }

        public void Debug(string message)
        {
            _logger.Log(LogLevel.Debug, message);
        }

        public void Debug(string message, params object[] args)
        {
            _logger.Log(LogLevel.Debug, message, args);
        }

        public void Debug(string message, Exception exception)
        {
            _logger.Log(LogLevel.Debug, exception, message);
        }

        public void Info(string message)
        {
            _logger.Log(LogLevel.Info, message);
        }

        public void Info(string message, params object[] args)
        {
            _logger.Log(LogLevel.Info, message, args);
        }

        public void Info(string message, Exception exception)
        {
            _logger.Log(LogLevel.Info, exception, message);
        }

        public void Warn(string message)
        {
            _logger.Log(LogLevel.Warn, message);
        }

        public void Warn(string message, params object[] args)
        {
            _logger.Log(LogLevel.Warn, message, args);
        }

        public void Warn(string message, Exception exception)
        {
            _logger.Log(LogLevel.Warn, exception, message);
        }

        public void Error(string message)
        {
            _logger.Log(LogLevel.Error, message);
        }

        public void Error(string message, params object[] args)
        {
            _logger.Log(LogLevel.Error, message, args);
        }

        public void Error(string message, Exception exception)
        {
            _logger.Log(LogLevel.Error, exception, message);
        }

        public void Fatal(string message)
        {
            _logger.Log(LogLevel.Fatal, message);
        }

        public void Fatal(string message, params object[] args)
        {
            _logger.Log(LogLevel.Fatal, message, args);
        }

        public void Fatal(string message, Exception exception)
        {
            _logger.Log(LogLevel.Fatal, exception, message);
        }
    }
}
