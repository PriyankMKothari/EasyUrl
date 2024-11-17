using Microsoft.AspNetCore.Mvc;
using EasyUrl.Application;

namespace EasyUrl.Api.Controllers;

/// <summary>
/// Feature - Quick Links
/// Generate and return code without storing it in the database
/// </summary>
/// <param name="urlShortener"></param>
/// <param name="controllerLogger"></param>
[ApiController]
[Route("basic")]
public class BasicController(IUrlShortener urlShortener, ILogger<BasicController> controllerLogger) : ControllerBase
{
    private readonly IUrlShortener _urlShortener =
        urlShortener ?? throw new ArgumentNullException(nameof(urlShortener));
        
    private readonly ILogger<BasicController> _controllerLogger =
        controllerLogger ?? throw new ArgumentNullException(nameof(controllerLogger));
        
    [HttpGet("{url}")]
    public async Task<IActionResult> Get([FromRoute] string url, CancellationToken cancellationToken)
    {
        // if(!Uri.TryCreate(url, UriKind.Absolute, out var uri))
        // {
        //     return BadRequest("Invalid URL");
        // }
        //
        // var tagModel = await this._urlShortener.GetShortUrlAsync(uri, cancellationToken).ConfigureAwait(false);
        // return Ok(tagModel);
        throw new NotImplementedException();
    }

    [HttpPost("{url}")]
    public async Task<IActionResult> Create([FromRoute] string url, CancellationToken cancellationToken)
    {
        // if(!Uri.TryCreate(url, UriKind.Absolute, out var uri))
        // {
        //     return BadRequest("Invalid URL");
        // }
        //
        // var tagModel = await this._urlShortener.CreateShortUrlAsync(uri, cancellationToken).ConfigureAwait(false);
        // return Ok(tagModel);
        throw new NotImplementedException();
    }
}