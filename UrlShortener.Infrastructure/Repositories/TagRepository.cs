using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UrlShortener.Persistent.DbContexts;
using UrlShortener.Persistent.Entities;

namespace UrlShortener.Persistent.Repositories
{
    public sealed class TagRepository : ITagRepository
    {
        private readonly DatabaseContext _databaseContext;

        /// <summary>
        /// Initiates a new instance of <see cref="TagRepository" />.
        /// </summary>
        /// <param name="databaseContext"><see cref="DatabaseContext" />.</param>
        public TagRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        /// <inheritdoc />
        public async Task<Tag> CreateAsync(Tag tag, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(tag, nameof(tag));

            this._databaseContext.Add(tag);
            await this._databaseContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return tag;
        }

        /// <inheritdoc />
        public async Task<Tag> DeleteAsync(Tag tag, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(tag, nameof(tag));

            this._databaseContext.Remove(tag);
            await this._databaseContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return tag;
        }

        /// <inheritdoc />
        public async Task<bool> ExistsAsync(Expression<Func<Tag, bool>> predicateExpression, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(predicateExpression, nameof(predicateExpression));

            return await this._databaseContext.Set<Tag>().AnyAsync(predicateExpression, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<IList<Tag>> GetAllAsync(Expression<Func<Tag, bool>> predicateExpression, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(predicateExpression, nameof(predicateExpression));

            return await this._databaseContext.Set<Tag>().AsNoTracking().ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Tag?> GetAsync(Expression<Func<Tag, bool>> predicateExpression, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(predicateExpression, nameof(predicateExpression));

            return await this._databaseContext.Set<Tag>().AsNoTracking().SingleOrDefaultAsync(predicateExpression, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Tag> UpdateAsync(Tag item, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            // get local entity
            var localEntity = this._databaseContext.Set<Tag>().Local.FirstOrDefault(entry => entry.Id.Equals(item.Id));

            // check if local entity is not null 
            if (localEntity != null)
                this._databaseContext.Entry((object)localEntity).State = EntityState.Detached;

            this._databaseContext.Update(item);
            await this._databaseContext.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false);
            return item;
        }
    }
}
