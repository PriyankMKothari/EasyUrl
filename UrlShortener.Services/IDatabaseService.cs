using UrlShortener.Services.Models;

namespace UrlShortener.Services;

/// <summary>
/// Service to Add, Update, Delete and Read <see cref="TagModel" /> entity from database.
/// </summary>
public interface IDatabaseService
{
    /// <summary>
    /// Creates <see cref="TagModel" />.
    /// </summary>
    /// <param name="tag"><see cref="TagModel" />.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken "/>.</param>
    /// <returns>Newly created <see cref="TagModel" />.</returns>
    Task<TagModel> CreateAsync(TagModel tag, CancellationToken cancellationToken);

    /// <summary>
    /// Gets <see cref="TagModel" /> by id.
    /// </summary>
    /// <param name="id">Tag id.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see cref="TagModel" />.</returns>
    Task<TagModel?> GetAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Gets <see cref="TagModel" /> by shortened code.
    /// </summary>
    /// <param name="code">Shortened code.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see cref="TagModel" />.</returns>
    Task<TagModel?> GetByShortCodeAsync(string code, CancellationToken cancellationToken);

    /// <summary>
    /// Gets <see cref="TagModel" /> by long url.
    /// </summary>
    /// <param name="url">Long url.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see cref="TagModel" />.</returns>
    Task<TagModel?> GetByLongUrlAsync(string url, CancellationToken cancellationToken);

    /// <summary>
    /// Updates <see cref="TagModel" />.
    /// </summary>
    /// <param name="tag"><see cref="TagModel" />.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns>Updated <see cref="TagModel" />.</returns>
    Task<TagModel?> UpdateAsync(TagModel tag, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes <see cref="TagModel" />.
    /// </summary>
    /// <param name="id">Tag id.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns>Soft-deleted <see cref="TagModel" />.</returns>
    Task<TagModel?> DeleteAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Checks if the code already exists.
    /// </summary>
    /// <param name="code">Shortened code.</param>
    /// <param name="CancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see langword="true" /> if <see cref="TagModel.Code" /> exists, otherwise <see langword="false" /></returns>
    Task<bool> ShortCodeExistsAsync(string code, CancellationToken CancellationToken);

    /// <summary>
    /// Checks if the url already exists.
    /// </summary>
    /// <param name="url">Long url.</param>
    /// <param name="CancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see langword="true" /> if <see cref="TagModel.Url" /> exists, otherwise <see langword="false" /></returns>
    Task<bool> LongUrlExistsAsync(string url, CancellationToken CancellationToken);

    /// <summary>
    /// Gets shortened code from the long url.
    /// </summary>
    /// <param name="url">Long url.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns>A <see cref="string" /> generated from the <paramref name="url" />.</returns>
    Task<string?> GetShortCodeAsync(string url, CancellationToken cancellationToken);

    /// <summary>
    /// Gets long url by shortened code.
    /// </summary>
    /// <param name="code">Shortened code.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns>An original url that was shortened generating the <paramref name="code" />.</returns>
    Task<string?> GetLongUrlAsync(string code, CancellationToken cancellationToken);
}