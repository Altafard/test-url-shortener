using System;
using Api.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly IShortenerService _service;

        public UrlController(IShortenerService service) => _service = service ?? throw new ArgumentNullException(nameof(service));

        [HttpGet]
        public IActionResult Get(string shortUrl)
        {
            if (string.IsNullOrEmpty(shortUrl))
            {
                return BadRequest();
            }

            string longUrl = _service.Obtain(shortUrl);
            return Ok(longUrl);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string longUrl)
        {
            if (string.IsNullOrEmpty(longUrl))
            {
                return BadRequest();
            }

            string shortUrl = _service.Create(longUrl);
            return Ok(shortUrl);
        }
    }
}