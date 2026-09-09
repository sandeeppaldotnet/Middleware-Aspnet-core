using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Class4_Middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {


        public IActionResult GetProducts()
        {
            var products = new[]
            {
                new { Id = 1, Name = "Product 1", Price = 10.99 },
                new { Id = 2, Name = "Product 2", Price = 19.99 },
                new { Id = 3, Name = "Product 3", Price = 5.99 }
            };

            return Ok(products);
        }

    }
}
