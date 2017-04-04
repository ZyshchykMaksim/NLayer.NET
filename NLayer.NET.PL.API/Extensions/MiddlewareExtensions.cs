using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLayer.NET.BLL.Logger;
using NLayer.NET.PL.API.Middlewares;
using Owin;

namespace NLayer.NET.PL.API.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="logFactory"></param>
        /// <returns></returns>
        public static IAppBuilder UseLoggingMiddleware(this IAppBuilder app, LogFactory logFactory)
        {
            app.Use<LoggingMiddleware>(logFactory);
            return app;
        }
    }
}