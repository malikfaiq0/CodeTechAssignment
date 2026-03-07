using System.Net;
using System.Text.Json;

namespace CodeTechAssignment.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var response = new { message = ex.Message, details = "An error occurred during processing." };
                var jsonResponse = JsonSerializer.Serialize(response);
                await httpContext.Response.WriteAsync(jsonResponse);
            }
        }
    }
}
