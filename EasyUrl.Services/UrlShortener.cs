using EasyUrl.Application;
using EasyUrl.Services.Models;
using Microsoft.Extensions.Logging;

namespace EasyUrl.Services;

/// <summary>
/// Implementation of <see cref="IUrlShortener" />.
/// </summary>
public sealed class UrlShortener(
    IDatabaseService databaseService,
    ICodeService codeGeneratorService,
    ILogger<IUrlShortener> logger) : IUrlShortener
{
    private readonly IDatabaseService _databaseService =
        databaseService ?? throw new ArgumentNullException(nameof(databaseService));
    private readonly ICodeService _codeService =
        codeGeneratorService ?? throw new ArgumentNullException(nameof(codeGeneratorService));
    private readonly ILogger<IUrlShortener> _logger =
        logger ?? throw new ArgumentNullException(nameof(logger));

    public Task<string> CreateShortUrlAsync(string originalUrl, string? customAlias, DateTimeOffset? expirationDateTimeOffset,
        string? customDomain, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetOriginalUrlAsync(string shortUrl, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}