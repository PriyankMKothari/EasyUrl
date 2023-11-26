namespace UrlShortener.Application
{
    /// <summary>
    /// Service to get <see cref="ITagModel.Code" /> or <see cref="ITagModel.Url" />.
    /// </summary>
    public interface IUrlShortenerService
    {
        /// <summary>
        /// Creates short code from the url.
        /// </summary>
        /// <param name="url">Url.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns></returns>
        Task<ITagModel> GenerateShortCodeAsync(string url, CancellationToken cancellationToken);

        /// <summary>
        /// Gets short code from the url.
        /// </summary>
        /// <param name="url">Url.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>A <see cref="string" /> generated from the <paramref name="url" />.</returns>
        Task<ITagModel> GetShortCodeAsync(string url, CancellationToken cancellationToken);

        /// <summary>
        /// Gets long url from the code.
        /// </summary>
        /// <param name="code">Shortened code.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
        /// <returns>An original url that was shortened generating the <paramref name="code" />.</returns>
        Task<ITagModel> GetLongUrlAsync(string code, CancellationToken cancellationToken);
    }
}
