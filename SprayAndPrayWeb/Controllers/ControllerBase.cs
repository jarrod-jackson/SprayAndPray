using SprayAndPrayWeb.Logging;
using System.Diagnostics;
using System.Net;
using System.Web.Http;
using ILogger = SprayAndPrayWeb.Logging.ILogger;

namespace SprayAndPrayWeb.Controllers
{
    public class ControllerBase : ApiController
    {
        public ControllerBase()
        {
            _logger = new Logger("SprayAndPrayInternalApi");
        }
        protected ILogger _logger { get; }

        protected async Task<HttpResponseMessage> GetHttpResponse(
            HttpRequestMessage request,
            Func<Task<HttpResponseMessage>> codeToExecute)
        {
            HttpResponseMessage response;
            var stopwatch = Stopwatch.StartNew();
            var requestId = Guid.NewGuid().ToString();
            var idPath = $"{requestId} {request.RequestUri.PathAndQuery}";

            _logger.InfoFormat(idPath);
            try
            {
                response = await codeToExecute.Invoke();

                _logger.Debug($"{idPath}: HttpCode {response.StatusCode} api request elapsed {stopwatch.ElapsedMilliseconds} ms");
            }
            catch (Exception ex)
            {
                response = HandleException(request, idPath, ex, HttpStatusCode.InternalServerError);
            }

            _logger.InfoFormat("{0}: HttpCode {1} elapsed {2}ms", idPath, response.StatusCode, stopwatch.ElapsedMilliseconds);

            return response;
        }

        public HttpResponseMessage HandleException(
            HttpRequestMessage request,
            string idPath,
            Exception ex,
            HttpStatusCode statusCode)
        {
            var body = Request.Content != null
                ? Request.Content.ReadAsStringAsync().Result
                : string.Empty;

            var errorInfo = $"{idPath}, body: {body}, Exception: {ex}";
            _logger.Error(errorInfo);

            HttpResponseMessage response;

            response = request.CreateResponse(statusCode, ex);

            return response;
        }
    }
}
