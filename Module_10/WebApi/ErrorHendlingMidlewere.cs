namespace WebApi
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Features;
    using Microsoft.Extensions.Logging;

    public class ErrorHendlingMidlewere
    {
        private const string MessageFormat = "HTTP {0} {1} responsed {2}";

        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHendlingMidlewere> _logger;

        public ErrorHendlingMidlewere(RequestDelegate next, ILogger<ErrorHendlingMidlewere> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                int? statusCode = null;
                if (httpContext.Response != null)
                {
                    statusCode = httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }

                _logger.LogError(ex, MessageFormat, httpContext.Request.Method, GetPath(httpContext), statusCode);
            }
        }

        private string GetPath(HttpContext httpContext)
        {
            return httpContext.Features.Get<IHttpRequestFeature>()?.RawTarget ?? httpContext.Request.Path.ToString();
        }
    }
}