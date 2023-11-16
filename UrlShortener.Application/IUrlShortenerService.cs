namespace UrlShortener.Application
{
    public interface IUrlShortenerService
    {
        /// <summary>
        /// Creates short code from the url.
        /// </summary>
        /// <param name="url">Url.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns></returns>
        Task<string> GenerateShortCodeAsync(string url, CancellationToken cancellationToken);

        /// <summary>
        /// Gets short code from the url.
        /// </summary>
        /// <param name="url">Url.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>A <see cref="string" /> generated from the <paramref name="url" />.</returns>
        Task<string> GetShortCodeAsync(string url, CancellationToken cancellationToken);

        /// <summary>
        /// Gets long url from the code.
        /// </summary>
        /// <param name="code">Shortened code.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>An original url that was shortened generating the <paramref name="code" />.</returns>
        Task<string> GetLongUrlAsync(string code, CancellationToken cancellationToken);
    }
}
