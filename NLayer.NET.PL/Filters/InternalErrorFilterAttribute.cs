using NLayer.NET.BLL.Logger;
using System.Web.Mvc;

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
        private readonly ILog<InternalErrorFilterAttribute> _logService = (new LogFactory()).CreateLogger<InternalErrorFilterAttribute>();

        /// <summary>
        /// Handle exception
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            _logService.Error(context.Exception.Message, context.Exception);

            context.ExceptionHandled = true;
        }
    }
}