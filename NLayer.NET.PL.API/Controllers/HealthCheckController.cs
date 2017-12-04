using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLayer.HealthCheck;
using NLayer.HealthCheck.Models.Enums;
using NLayer.PL.API.Helpers.HealthCheck;
using Swashbuckle.Swagger.Annotations;

namespace NLayer.PL.API.Controllers
{
    /// <summary>
    /// HealthCheckController.
    /// </summary>
    public class HealthCheckController : ApiController
    {
        private readonly IHealthChecker healthChecker;

        private const string HealthCheckSuccessfulResponseContent = "Ok";

        private const string HealthCheckFailedResponseContent = "Failure";

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckController"/> class.
        /// </summary>
        /// <param name="healthChecker">The health checker.</param>
        public HealthCheckController(IHealthChecker healthChecker)
        {
            this.healthChecker = healthChecker;
        }

        /// <summary>
        /// Healthes the check.
        /// </summary>
        /// <param name="details">Indicates about DETAILED Health check type.</param>
        /// <param name="warn">Indicates about WARN Health check type.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/healthcheck")]
        [SwaggerOperation("HealthCheck")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.ServiceUnavailable)]
        public IHttpActionResult HealthCheck(bool? details = false, bool? warn = false)
        {
            var result = healthChecker.Check(
               new List<IHealthCheck>()
               {
                   new ApplicationDatabaseHealthCheck()
               }
           );

            var response = Request.CreateResponse();

            response.Headers.CacheControl = new CacheControlHeaderValue
            {
                NoCache = true,
                NoStore = true,
                MustRevalidate = true
            };

            if (!warn.HasValue || warn.Value)
            {
                if (result.Status == HealthCheckStatus.Healthy)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Content = new StringContent(HealthCheckSuccessfulResponseContent);
                }
                else
                {
                    response.StatusCode = HttpStatusCode.ServiceUnavailable;
                    response.Content = new StringContent(HealthCheckFailedResponseContent);
                }
            }
            else if (!details.HasValue || details.Value)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new StringContent(
                    JsonConvert.SerializeObject(
                        result,
                        Formatting.Indented,
                        new StringEnumConverter()
                    )
                );
            }
            else
            {
                if (result.Status == HealthCheckStatus.Error)
                {
                    response.StatusCode = HttpStatusCode.ServiceUnavailable;
                    response.Content = new StringContent(HealthCheckFailedResponseContent);
                }
                else
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Content = new StringContent(HealthCheckSuccessfulResponseContent);
                }
            }

            return ResponseMessage(response);
        }
    }
}
