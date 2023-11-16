using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application;

namespace UrlShortener.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IUrlShortenerService _urlShortenerService;

        public UrlShortenerController(IUrlShortenerService urlShortenerService)
        {
            this._urlShortenerService = urlShortenerService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpGet("url/{longUrl}")]
        public async Task<IActionResult> GetByUrl([FromRoute] string longUrl, CancellationToken cancellationToken)
        {
            string code = await this._urlShortenerService.GetShortCodeAsync(longUrl, cancellationToken).ConfigureAwait(false);
            return Ok(code);
        }

        [HttpGet("code")]
        public async Task<IActionResult> GetByCode([FromRoute] string shortCode, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpPost("generate")]
        public async Task<IActionResult> Create([FromRoute] string url, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
