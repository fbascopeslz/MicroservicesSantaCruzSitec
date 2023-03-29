using Microsoft.AspNetCore.Mvc;

namespace Sale.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {        
        [HttpGet]
        public string Get()
        {
            return "Sale Microservice is running...";
        }
    }
}