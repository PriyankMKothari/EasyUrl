using EasyUrl.Services.Mappers;
using EasyUrl.Persistent.Repositories;
using EasyUrl.Services.Models;
using Microsoft.Extensions.Logging;

namespace EasyUrl.Services;

/// <summary>
/// Implementation of the <see cref="IDatabaseService" />.
/// </summary>
public sealed class DatabaseService(IEasyUrlRepository easyUrlRepository, ILogger<IDatabaseService> logger) : IDatabaseService
{
    private readonly IEasyUrlRepository _easyUrlRepository =
        easyUrlRepository ?? throw new ArgumentNullException(nameof(easyUrlRepository));
    private readonly ILogger<IDatabaseService> _logger =
        logger ?? throw new ArgumentNullException(nameof(logger));

    /// <inheritdoc/>
    public async Task<EasyUrlModel> CreateAsync(EasyUrlModel easyUrl, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(easyUrl, nameof(easyUrl));

        EasyUrlModel? tagModel = null;

        try
        {
            Persistent.Entities.EasyUrl? entity = await _easyUrlRepository.CreateAsync(easyUrl.ToEntity(), cancellationToken).ConfigureAwait(false);
            tagModel = entity.ToModel();
        }
        catch
        {
            throw;
        }

        return tagModel;
    }

    /// <inheritdoc/>
    public async Task<EasyUrlModel?> GetAsync(int id, CancellationToken cancellationToken)
    {
        EasyUrlModel? tagModel = null;

        try
        {
            Persistent.Entities.EasyUrl? entity = await _easyUrlRepository.GetAsync(tag => tag.Id.Equals(id), cancellationToken).ConfigureAwait(false);
            tagModel = entity?.ToModel();
        }
        catch
        {
            throw;
        }

        return tagModel;
    }

    /// <inheritdoc/>
    public async Task<EasyUrlModel?> GetByShortCodeAsync(string code, CancellationToken cancellationToken)
    {
        EasyUrlModel? tagModel = null;

        try
        {
            Persistent.Entities.EasyUrl? entity = await _easyUrlRepository.GetAsync(tag => tag.ShortUrl.Equals(code, StringComparison.OrdinalIgnoreCase), cancellationToken).ConfigureAwait(false);
            tagModel = entity?.ToModel();
        }
        catch
        {
            throw;
        }

        return tagModel;
    }

    /// <inheritdoc/>
    public async Task<EasyUrlModel?> GetByLongUrlAsync(string url, CancellationToken cancellationToken)
    {
        EasyUrlModel? tagModel = null;

        try
        {
            Persistent.Entities.EasyUrl? entity =
                await _easyUrlRepository.GetAsync(tag => tag.OriginalUrl.Equals(url, StringComparison.OrdinalIgnoreCase), cancellationToken).ConfigureAwait(false);
            tagModel = entity?.ToModel();
        }
        catch
        {
            throw;
        }

        return tagModel;
    }

    /// <inheritdoc/>
    public async Task<EasyUrlModel?> UpdateAsync(EasyUrlModel easyUrl, CancellationToken cancellationToken)
    {
        EasyUrlModel? tagModel = null;

        try
        {
            Persistent.Entities.EasyUrl? entity = await _easyUrlRepository.UpdateAsync(easyUrl.ToEntity(), cancellationToken).ConfigureAwait(false);
            tagModel = entity?.ToModel();
        }
        catch
        {
            throw;
        }

        return tagModel;
    }

    /// <inheritdoc/>
    public async Task<EasyUrlModel?> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public async Task<bool> ShortCodeExistsAsync(string code, CancellationToken cancellationToken)
    {
        bool shortCodeExists = false;

        try
        {
            shortCodeExists = await _easyUrlRepository.ExistsAsync(tag => tag.ShortUrl.Equals(code, StringComparison.OrdinalIgnoreCase), cancellationToken);
        }
        catch
        {
            throw;
        }

        return shortCodeExists;
    }

    /// <inheritdoc/>
    public async Task<bool> LongUrlExistsAsync(string url, CancellationToken cancellationToken)
    {
        bool longUrlExists = false;

        try
        {
            longUrlExists = await _easyUrlRepository.ExistsAsync(tag => tag.OriginalUrl.Equals(url, StringComparison.OrdinalIgnoreCase), cancellationToken);
        }
        catch
        {
            throw;
        }

        return longUrlExists;
    }

    /// <inheritdoc/>
    public async Task<string?> GetShortCodeAsync(string url, CancellationToken cancellationToken)
    {
        try
        {
            Persistent.Entities.EasyUrl? entity = await _easyUrlRepository.GetAsync(tag => tag.OriginalUrl == url, cancellationToken).ConfigureAwait(false);
            return entity?.ShortUrl ?? string.Empty;
        }
        catch
        {
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<string?> GetLongUrlAsync(string code, CancellationToken cancellationToken)
    {
        try
        {
            Persistent.Entities.EasyUrl? entity =
                await _easyUrlRepository.GetAsync(tag => tag.ShortUrl.Equals(code, StringComparison.OrdinalIgnoreCase), cancellationToken).ConfigureAwait(false);
            return entity?.OriginalUrl ?? string.Empty;
        }
        catch
        {
            throw;
        }
    }
}