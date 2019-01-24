using System;
using System.Threading.Tasks;
using Api.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly IShortenerService _service;

        public StatsController(IShortenerService service) => _service = service ?? throw new ArgumentNullException(nameof(service));

        [HttpGet]
        public async Task<IActionResult> Get(string shortUrl)
        {
            if (string.IsNullOrEmpty(shortUrl))
            {
                return BadRequest();
            }

            int clicks = await _service.GetClicks(shortUrl);
            return Ok(clicks);
        }
    }
}
