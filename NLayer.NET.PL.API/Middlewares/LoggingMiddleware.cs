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
            var startTime = DateTime.UtcNow;

            var watch = Stopwatch.StartNew();
            await Next.Invoke(context);
            watch.Stop();

            string logTemplate = $"{context.Request.Method} {context.Request.LocalIpAddress} {context.Request.Path} {Environment.NewLine}" +
                                  $"Start time: {startTime} Duration: {watch.ElapsedMilliseconds} milliseconds {Environment.NewLine}" +
                                  $"Request Headers: {Environment.NewLine} {context.Request.GetHeaderParameters()}" +
                                  $"Body: {Environment.NewLine} {context.Request.GetBodyParameters()}";

            //_logService.Info();
        }
    }
}