using API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet("{statusCode}")]
        public ActionResult Error(int statusCode)
        {
            return new ObjectResult(new ErrorResponse(statusCode));
        }
    }
}
