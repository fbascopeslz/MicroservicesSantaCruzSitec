using Microsoft.AspNetCore.Mvc;

namespace Product.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {                
        [HttpGet]
        public string Get()
        {
            return "Product Microservice is running...";
        }
    }
}