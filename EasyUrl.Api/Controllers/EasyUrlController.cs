using Microsoft.AspNetCore.Mvc;
using EasyUrl.Application;

namespace EasyUrl.Api.Controllers;

[ApiController]
[Route("easify")]
public class EasyUrlController(IUrlShortener urlShortener, ILogger<EasyUrlController> controllerLogger) : ControllerBase
{
    private readonly IUrlShortener _urlShortener =
        urlShortener ?? throw new ArgumentNullException(nameof(urlShortener));
        
    private readonly ILogger<EasyUrlController> _controllerLogger =
        controllerLogger ?? throw new ArgumentNullException(nameof(controllerLogger));
        
    [HttpGet("{url}")]
    public async Task<IActionResult> Get([FromRoute] string url, CancellationToken cancellationToken)
    {
        var tagModel = await this._urlShortener.GetCodeAsync(url, cancellationToken).ConfigureAwait(false);
        return Ok(tagModel);
    }

    [HttpPost("{url}")]
    public async Task<IActionResult> Create([FromRoute] string url, CancellationToken cancellationToken)
    {
        var tagModel = await this._urlShortener.GenerateCodeAsync(url, cancellationToken).ConfigureAwait(false);
        return Ok(tagModel);
    }
}