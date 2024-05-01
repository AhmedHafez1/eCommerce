using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string GetProducts()
        {
            return "187 Products";
        }

        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return $"Product with id {id}";
        }
    }
}
