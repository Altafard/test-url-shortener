using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class StatsController : ControllerBase
    {
        [HttpGet]
        public int Get(string shortUrl)
        {
            return 0;
        }
    }
}
