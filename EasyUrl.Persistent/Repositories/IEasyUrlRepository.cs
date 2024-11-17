using System.Linq.Expressions;
using EasyUrl.Persistent.Entities;

namespace EasyUrl.Persistent.Repositories;

/// <summary>
/// Repository to perform storage implementation for <see cref="EasyUrl" />.
/// </summary>
public interface IEasyUrlRepository
{
    /// <summary>
    /// Checks if any <see cref="Entities.EasyUrl" /> exists that match(es) condition(s).
    /// </summary>
    /// <param name="predicateExpression">Condition(s) to match</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see cref="Task" /> with <see langword="true" /> or <see langword="false" />.</returns>
    Task<bool> ExistsAsync(
        Expression<Func<Entities.EasyUrl, bool>> predicateExpression,
        CancellationToken cancellationToken);

    /// <summary>
    /// Adds <see cref="Entities.EasyUrl" /> to the database.
    /// </summary>
    /// <param name="easyUrl"><see cref="Entities.EasyUrl" /> to add.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns>Newly created <see cref="Entities.EasyUrl" />.</returns>
    Task<Entities.EasyUrl> CreateAsync(Entities.EasyUrl easyUrl, CancellationToken cancellationToken);
    
    /// <summary>
    /// Lists all <see cref="Entities.EasyUrl" />s that match(es) the condition(s).
    /// </summary>
    /// <param name="predicateExpression">Condition(s) to match.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see cref="Task" /> with all matching <see cref="Entities.EasyUrl" />.</returns>
    Task<List<Entities.EasyUrl>> ListAsync(
        Expression<Func<Entities.EasyUrl, bool>>? predicateExpression,
        CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets a <see cref="Entities.EasyUrl" /> that match(es) the condition(s).
    /// </summary>
    /// <param name="predicateExpression">Condition(s) to match.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see cref="Task" /> with a matching <see cref="Entities.EasyUrl" />.</returns>
    Task<Entities.EasyUrl?> GetAsync(
        Expression<Func<Entities.EasyUrl, bool>> predicateExpression,
        CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing <see cref="Entities.EasyUrl" />.
    /// </summary>
    /// <param name="easyUrl"><see cref="Entities.EasyUrl" /> to update</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see cref="Task" /> with the updated <see cref="Entities.EasyUrl" />.</returns>
    Task<Entities.EasyUrl> UpdateAsync(Entities.EasyUrl easyUrl, CancellationToken cancellationToken);
    
    /// <summary>
    /// Deletes existing <see cref="Entities.EasyUrl" />.
    /// </summary>
    /// <param name="predicateExpression">Condition(s) to match.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see cref="Task" /> with deleted <see cref="Entities.EasyUrl" />.</returns>
    Task<Entities.EasyUrl?> DeleteAsync(
        Expression<Func<Entities.EasyUrl, bool>> predicateExpression,
        CancellationToken cancellationToken);
}