using NLayer.Logging.NLog;
using NLayer.PL.API.Middlewares;
using Owin;

namespace NLayer.PL.API.Extensions
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