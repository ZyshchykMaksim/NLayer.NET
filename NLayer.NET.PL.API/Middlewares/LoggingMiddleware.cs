using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;
using NLayer.NET.BLL.Logger;
using NLayer.NET.PL.API.Extensions;

namespace NLayer.NET.PL.API.Middlewares
{
    /// <summary>
    /// 
    /// </summary>
    public class LoggingMiddleware : OwinMiddleware
    {
        private readonly ILog<LoggingMiddleware> _logService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logFactory">The logging service</param>
        public LoggingMiddleware(OwinMiddleware next, ILogFactory logFactory) : base(next)
        {
            _logService = logFactory.CreateLogger<LoggingMiddleware>();
        }

        /// <summary>
        /// Process an individual request.
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns></returns>
        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                var startTime = DateTime.UtcNow;

                var watch = Stopwatch.StartNew();
                await Next.Invoke(context);
                watch.Stop();

                string userName = context.Request.User != null && context.Request.User.Identity.IsAuthenticated ? context.Request.User.Identity.Name : "Anonymous";
                string logTemplate = $"{context.Request.Method} {userName} {context.Request.Path} {Environment.NewLine}" +
                                     $"Start time: {startTime} Duration: {watch.ElapsedMilliseconds} milliseconds {Environment.NewLine}" +
                                     $"Request Headers:{Environment.NewLine}{context.Request.GetHeaderParameters().ConvertToString()}{Environment.NewLine}" +
                                     $"Body:{Environment.NewLine}{context.Request.GetBody()}";

                _logService.Info(logTemplate);

            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
            }
        }
    }
}