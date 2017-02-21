using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace NLayer.NET.PL.Filters
{

    public class InternalErrorFilterAttribute : ExceptionFilterAttribute
    {
        
        //private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        // TODO add logger to store trace log of error

        public override void OnException(HttpActionExecutedContext context)
        {
            //_logger.FatalException(context.Exception.Message, context.Exception);

            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}