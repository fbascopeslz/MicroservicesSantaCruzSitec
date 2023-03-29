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
            return "Running...";
        }
    }
}