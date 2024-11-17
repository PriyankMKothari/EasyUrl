using EasyUrl.Services.Models;

namespace EasyUrl.Services;

/// <summary>
/// Service to Add, Update, Delete and Read <see cref="EasyUrlModel" /> entity from database.
/// </summary>
public interface IDatabaseService
{
    /// <summary>
    /// Creates <see cref="EasyUrlModel" />.
    /// </summary>
    /// <param name="easyUrl"><see cref="EasyUrlModel" />.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken "/>.</param>
    /// <returns>Newly created <see cref="EasyUrlModel" />.</returns>
    Task<EasyUrlModel> CreateAsync(EasyUrlModel easyUrl, CancellationToken cancellationToken);

    /// <summary>
    /// Gets <see cref="EasyUrlModel" /> by id.
    /// </summary>
    /// <param name="id">Tag id.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see cref="EasyUrlModel" />.</returns>
    Task<EasyUrlModel?> GetAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Gets <see cref="EasyUrlModel" /> by shortened code.
    /// </summary>
    /// <param name="code">Shortened code.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see cref="EasyUrlModel" />.</returns>
    Task<EasyUrlModel?> GetByShortCodeAsync(string code, CancellationToken cancellationToken);

    /// <summary>
    /// Gets <see cref="EasyUrlModel" /> by long url.
    /// </summary>
    /// <param name="url">Long url.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see cref="EasyUrlModel" />.</returns>
    Task<EasyUrlModel?> GetByLongUrlAsync(string url, CancellationToken cancellationToken);

    /// <summary>
    /// Updates <see cref="EasyUrlModel" />.
    /// </summary>
    /// <param name="easyUrl"><see cref="EasyUrlModel" />.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns>Updated <see cref="EasyUrlModel" />.</returns>
    Task<EasyUrlModel?> UpdateAsync(EasyUrlModel easyUrl, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes <see cref="EasyUrlModel" />.
    /// </summary>
    /// <param name="id">Tag id.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns>Soft-deleted <see cref="EasyUrlModel" />.</returns>
    Task<EasyUrlModel?> DeleteAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Checks if the code already exists.
    /// </summary>
    /// <param name="code">Shortened code.</param>
    /// <param name="CancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see langword="true" /> if <see cref="EasyUrlModel.ShortUrl" /> exists, otherwise <see langword="false" /></returns>
    Task<bool> ShortCodeExistsAsync(string code, CancellationToken CancellationToken);

    /// <summary>
    /// Checks if the url already exists.
    /// </summary>
    /// <param name="url">Long url.</param>
    /// <param name="CancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see langword="true" /> if <see cref="EasyUrlModel.OriginalUrl" /> exists, otherwise <see langword="false" /></returns>
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