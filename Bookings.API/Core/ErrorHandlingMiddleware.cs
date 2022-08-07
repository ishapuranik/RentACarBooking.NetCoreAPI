using System.Net;
using Bookings.Shared.Log;
using Newtonsoft.Json;

namespace Bookings.API.Core
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogWrapper _logWrapper;

        public ErrorHandlingMiddleware(ILogWrapper log)
        {
            _logWrapper = log;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
           try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            string result;
            var code = HttpStatusCode.InternalServerError;

            var errorMessage = ex.Message + ex.InnerException ?? "\nInner exception: " + ex.InnerException?.Message;

            if (ex is FluentValidation.ValidationException ||
                ex is System.ComponentModel.DataAnnotations.ValidationException)
            {
                code = HttpStatusCode.BadRequest;
            }

            if (ex is FluentValidation.ValidationException)
            {
                errorMessage = errorMessage.Replace("Validation failed: \r\n -- ", "");

                int innerExceptionIndex = errorMessage.IndexOf("\nInner exception", StringComparison.InvariantCulture);
                if (innerExceptionIndex >= 0)
                    errorMessage = errorMessage.Remove(innerExceptionIndex);

                result = JsonConvert.SerializeObject(new { errorMessage });
            }
            else
            {
                result = errorMessage;
                _logWrapper.Error(ex);
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}
