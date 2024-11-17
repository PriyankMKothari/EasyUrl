using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using EasyUrl.Persistent.DbContexts;
using EasyUrl.Persistent.Entities;

namespace EasyUrl.Persistent.Repositories;

public sealed class EasyUrlRepository(DatabaseContext databaseContext) : IEasyUrlRepository
{
    private readonly DatabaseContext _databaseContext =
        databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));

    /// <inheritdoc />
    public async Task<bool> ExistsAsync(
        Expression<Func<Entities.EasyUrl, bool>> predicateExpression,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(predicateExpression, nameof(predicateExpression));

        return await this._databaseContext
            .Set<Entities.EasyUrl>()
            .AnyAsync(predicateExpression, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<Entities.EasyUrl> CreateAsync(
        Entities.EasyUrl easyUrl,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(easyUrl, nameof(easyUrl));

        this._databaseContext.Add(easyUrl);
        await this._databaseContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return easyUrl;
    }
    
    /// <inheritdoc />
    public async Task<List<Entities.EasyUrl>> ListAsync(
        Expression<Func<Entities.EasyUrl, bool>>? predicateExpression,
        CancellationToken cancellationToken)
    {
        var query = _databaseContext.Set<Entities.EasyUrl>().AsNoTracking();

        if (predicateExpression is not null)
        {
            query = query.Where(predicateExpression);
        }

        return await query.ToListAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<Entities.EasyUrl?> GetAsync(
        Expression<Func<Entities.EasyUrl, bool>> predicateExpression,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(predicateExpression, nameof(predicateExpression));

        return await this._databaseContext
            .Set<Entities.EasyUrl>()
            .AsNoTracking()
            .FirstOrDefaultAsync(predicateExpression, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<Entities.EasyUrl> UpdateAsync(
        Entities.EasyUrl easyUrl,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(easyUrl, nameof(easyUrl));

        // get local entity
        var localEntity = this._databaseContext
            .Set<Entities.EasyUrl>()
            .Local
            .FirstOrDefault(entry => entry.Id.Equals(easyUrl.Id));

        // check if local entity is not null 
        if (localEntity != null)
            this._databaseContext.Entry((object)localEntity).State = EntityState.Detached;

        this._databaseContext.Update(easyUrl);
        await this._databaseContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return easyUrl;
    }
    
    /// <inheritdoc />
    public async Task<Entities.EasyUrl?> DeleteAsync(
        Expression<Func<Entities.EasyUrl, bool>> predicateExpression,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(predicateExpression, nameof(predicateExpression));

        var item = await this._databaseContext
            .Set<Entities.EasyUrl>()
            .FirstOrDefaultAsync(predicateExpression, cancellationToken)
            .ConfigureAwait(false);

        if (item is null) return null;
        
        _databaseContext.Set<Entities.EasyUrl>().Remove(item);
        await _databaseContext.SaveChangesAsync(true, cancellationToken).ConfigureAwait(false);
        return item;
    }
}