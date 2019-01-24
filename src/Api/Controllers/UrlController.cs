using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class UrlController : ControllerBase
    {
        [HttpGet]
        public string Get(string shortUrl)
        {
            return "long";
        }

        [HttpPost]
        public string Post([FromBody] string longUrl)
        {
            return "short";
        }
    }
}