using System.Web.Mvc;
using NLayer.Logging;
using NLayer.Logging.NLog;

namespace NLayer.NET.PL.Filters
{
    /// <summary>
    /// Internal filter attribute
    /// </summary>
    public class InternalErrorFilterAttribute : ActionFilterAttribute, IExceptionFilter
    {
        /// <summary>
        /// Log service
        /// </summary>
        private readonly ILog<InternalErrorFilterAttribute> logService = (new LogFactory()).CreateLogger<InternalErrorFilterAttribute>();

        /// <summary>
        /// Handle exception
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            logService.Error(context.Exception.Message, context.Exception);

            context.ExceptionHandled = true;
        }
    }
}