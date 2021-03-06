﻿using System;
using NLog;

namespace NLayer.Logging.NLog
{
    public class Log<T> : ILog<T> where T : class
    {
        private readonly global::NLog.Logger logger;

        public Log()
        {
            logger = LogManager.GetLogger(typeof(T).FullName);
        }

        public void Trace(string message)
        {
            logger.Log(LogLevel.Trace, message);
        }

        public void Trace(string message, params object[] args)
        {
            logger.Log(LogLevel.Trace, message, args);
        }

        public void Trace(string message, Exception exception)
        {
            logger.Log(LogLevel.Trace, exception, message);
        }

        public void Debug(string message)
        {
            logger.Log(LogLevel.Debug, message);
        }

        public void Debug(string message, params object[] args)
        {
            logger.Log(LogLevel.Debug, message, args);
        }

        public void Debug(string message, Exception exception)
        {
            logger.Log(LogLevel.Debug, exception, message);
        }

        public void Info(string message)
        {
            logger.Log(LogLevel.Info, message);
        }

        public void Info(string message, params object[] args)
        {
            logger.Log(LogLevel.Info, message, args);
        }

        public void Info(string message, Exception exception)
        {
            logger.Log(LogLevel.Info, exception, message);
        }

        public void Warn(string message)
        {
            logger.Log(LogLevel.Warn, message);
        }

        public void Warn(string message, params object[] args)
        {
            logger.Log(LogLevel.Warn, message, args);
        }

        public void Warn(string message, Exception exception)
        {
            logger.Log(LogLevel.Warn, exception, message);
        }

        public void Error(string message)
        {
            logger.Log(LogLevel.Error, message);
        }

        public void Error(string message, params object[] args)
        {
            logger.Log(LogLevel.Error, message, args);
        }

        public void Error(string message, Exception exception)
        {
            logger.Log(LogLevel.Error, exception, message);
        }

        public void Fatal(string message)
        {
            logger.Log(LogLevel.Fatal, message);
        }

        public void Fatal(string message, params object[] args)
        {
            logger.Log(LogLevel.Fatal, message, args);
        }

        public void Fatal(string message, Exception exception)
        {
            logger.Log(LogLevel.Fatal, exception, message);
        }
    }
}
