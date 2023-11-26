using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application;

namespace UrlShortener.Api.Controllers
{
    [ApiController]
    [Route("shortener")]
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

        [HttpGet("url/{url}")]
        public async Task<IActionResult> GetByUrl([FromRoute] string url, CancellationToken cancellationToken)
        {
            var tagModel = await this._urlShortenerService.GetShortCodeAsync(url, cancellationToken).ConfigureAwait(false);
            return Ok(tagModel);
        }

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode([FromRoute] string code, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpPost("url/{url}")]
        public async Task<IActionResult> Create([FromRoute] string url, CancellationToken cancellationToken)
        {
            var tagModel = await this._urlShortenerService.GenerateShortCodeAsync(url, cancellationToken).ConfigureAwait(false);
            return Ok(tagModel);
        }

        [HttpDelete("url/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
