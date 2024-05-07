
using API.Errors;
using System.Net;
using System.Text.Json;

namespace API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IHostEnvironment _env;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleException(ex, context);
            }
        }

        public async Task HandleException(Exception ex, HttpContext context)
        {
            _logger.LogError(ex, ex.Message);
            var errorResponse = _env.IsDevelopment() ?
                new ErrorResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                : new ErrorResponse((int)HttpStatusCode.InternalServerError);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(errorResponse, options);

            await context.Response.WriteAsync(json);
        }
    }
}
