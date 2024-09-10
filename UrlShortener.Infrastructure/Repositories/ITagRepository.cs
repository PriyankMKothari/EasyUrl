using System.Linq.Expressions;
using EasyUrl.Persistent.Entities;

namespace EasyUrl.Persistent.Repositories;

/// <summary>
/// Repository to perform storage implementation for <see cref="Tag" />.
/// </summary>
public interface ITagRepository
{
    /// <summary>
    /// Adds <see cref="Tag" /> to the database.
    /// </summary>
    /// <param name="tag"><see cref="Tag" /> to add.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns>Newly created <see cref="Tag" />.</returns>
    Task<Tag> CreateAsync(Tag tag, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes existing <see cref="Tag" />.
    /// </summary>
    /// <param name="tag"><see cref="Tag" /> to delete</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see cref="Task" />.</returns>
    Task<Tag> DeleteAsync(Tag tag, CancellationToken cancellationToken);

    /// <summary>
    /// Checks if any <see cref="Tag" /> exists that match(es) condition(s).
    /// </summary>
    /// <param name="predicateExpression">Condition(s) to match</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see cref="Task{bool}" />.</returns>
    Task<bool> ExistsAsync(Expression<Func<Tag, bool>> predicateExpression, CancellationToken cancellationToken);

    /// <summary>
    /// Gets a tag that match(es) the condition(s).
    /// </summary>
    /// <param name="predicateExpression">Condition(s) to match</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see cref="Task{Tag}" />.</returns>
    Task<Tag?> GetAsync(Expression<Func<Tag, bool>> predicateExpression, CancellationToken cancellationToken);

    /// <summary>
    /// Gets all <see cref="Tag" />s that match(es) the condition(s).
    /// </summary>
    /// <param name="predicateExpression">Condition(s) to match.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns><see cref="Task{IList<see cref="Tag" />}" />.</returns>
    Task<IList<Tag>> GetAllAsync(Expression<Func<Tag, bool>> predicateExpression, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing <see cref="Tag" />.
    /// </summary>
    /// <param name="tag"><see cref="Tag" /> to update</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns>Updated <see cref="Tag" />.</returns>
    Task<Tag> UpdateAsync(Tag tag, CancellationToken cancellationToken);
}