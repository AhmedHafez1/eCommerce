
using Microsoft.AspNetCore.Mvc;

namespace API.Errors
{
    public class ErrorResponse : ProblemDetails
    {
        public ErrorResponse(int status, string? message = null, string? detail = null, IEnumerable<string>? errors = null)
        {
            Status = status;
            Message = message ?? GetDefaultErrorMessage(status);
            Detail = detail;
            Errors = errors;
        }

        public string Message { get; set; }
        public IEnumerable<string>? Errors { get; set; }

        private string GetDefaultErrorMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad request!",
                401 => "You are not authorized!",
                403 => "Forbidden!",
                404 => "Not found!",
                500 => "Server error!",
                _ => "An error occured!"
            };
        }
    }
}
