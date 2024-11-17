namespace EasyUrl.Application;

/// <summary>
/// 
/// </summary>
public interface IUrlShortener
{
    /// <summary>
    /// Creates and returns short url from the original url.
    /// </summary>
    /// <param name="originalUrl">Original Url.</param>
    /// <param name="customAlias">Custom Alias.</param>
    /// <param name="expirationDateTimeOffset">Expiration Date.</param>
    /// <param name="customDomain">Custom Domain.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns>Short url.</returns>
    Task<string> CreateShortUrlAsync(
        string originalUrl,
        string? customAlias,
        DateTimeOffset? expirationDateTimeOffset,
        string? customDomain,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets original url from the short url.
    /// </summary>
    /// <param name="shortUrl">Short url.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns>An original url that was shortened generating the <paramref name="shortUrl" />.</returns>
    Task<string> GetOriginalUrlAsync(string shortUrl, CancellationToken cancellationToken);
}