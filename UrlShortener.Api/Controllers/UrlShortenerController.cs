using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application;

namespace UrlShortener.Api.Controllers;

[ApiController]
[Route("shortener")]
public class UrlShortenerController(IUrlShortener urlShortener, ILogger<UrlShortenerController> controllerLogger) : ControllerBase
{
    private readonly IUrlShortener _urlShortener =
        urlShortener ?? throw new ArgumentNullException(nameof(urlShortener));
        
    private readonly ILogger<UrlShortenerController> _controllerLogger =
        controllerLogger ?? throw new ArgumentNullException(nameof(controllerLogger));
        
    [HttpGet("url/{url}")]
    public async Task<IActionResult> Get([FromRoute] string url, CancellationToken cancellationToken)
    {
        var tagModel = await this._urlShortener.GetCodeAsync(url, cancellationToken).ConfigureAwait(false);
        return Ok(tagModel);
    }

    [HttpPost("url/{url}")]
    public async Task<IActionResult> Create([FromRoute] string url, CancellationToken cancellationToken)
    {
        var tagModel = await this._urlShortener.GenerateCodeAsync(url, cancellationToken).ConfigureAwait(false);
        return Ok(tagModel);
    }
}