﻿using AutoMapper;
using UrlShortener.Persistent.Entities;
using UrlShortener.Persistent.Repositories;
using UrlShortner.Services.Models;

namespace UrlShortener.Services
{
    /// <summary>
    /// Implementation of the <see cref="IDatabaseService" />.
    /// </summary>
    public sealed class DatabaseService : IDatabaseService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _autoMapper;

        /// <summary>
        /// Initiates an instance of <see cref="DatabaseService" />.
        /// </summary>
        /// <param name="tagRepository"><see cref="ITagRepository" />.</param>
        /// <param name="autoMapper"><see cref="Mapper" />.</param>
        public DatabaseService(ITagRepository tagRepository, IMapper autoMapper)
        {
            this._tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
            this._autoMapper = autoMapper ?? throw new ArgumentNullException(nameof(autoMapper));
        }

        /// <inheritdoc/>
        public async Task<TagModel> CreateAsync(TagModel tag, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(tag, nameof(tag));

            TagModel? tagModel = null;

            try
            {
                Tag? entity = await this._tagRepository.CreateAsync(this._autoMapper.Map<Tag>(tag), cancellationToken).ConfigureAwait(false);
                tagModel = this._autoMapper.Map<TagModel>(entity);
            }
            catch
            {
                throw;
            }

            return tagModel;
        }

        /// <inheritdoc/>
        public async Task<TagModel?> GetAsync(int id, CancellationToken cancellationToken)
        {
            TagModel? tagModel = null;

            try
            {
                Tag? entity = await this._tagRepository.GetAsync(tag => tag.Id.Equals(id), cancellationToken).ConfigureAwait(false);
                tagModel = this._autoMapper.Map<TagModel>(entity);
            }
            catch
            {
                throw;
            }

            return tagModel;
        }

        /// <inheritdoc/>
        public async Task<TagModel?> GetByShortCodeAsync(string code, CancellationToken cancellationToken)
        {
            TagModel? tagModel = null;

            try
            {
                Tag? entity = await this._tagRepository.GetAsync(tag => tag.Code.Equals(code, StringComparison.OrdinalIgnoreCase), cancellationToken).ConfigureAwait(false);
                tagModel = this._autoMapper.Map<TagModel>(entity);
            }
            catch
            {
                throw;
            }

            return tagModel;
        }

        /// <inheritdoc/>
        public async Task<TagModel?> GetByLongUrlAsync(string url, CancellationToken cancellationToken)
        {
            TagModel? tagModel = null;

            try
            {
                Tag? entity =
                    await this._tagRepository.GetAsync(tag => tag.Url.Equals(url, StringComparison.OrdinalIgnoreCase), cancellationToken).ConfigureAwait(false);
                tagModel = this._autoMapper.Map<TagModel>(entity);
            }
            catch
            {
                throw;
            }

            return tagModel;
        }

        /// <inheritdoc/>
        public async Task<TagModel?> UpdateAsync(TagModel tag, CancellationToken cancellationToken)
        {
            TagModel? tagModel = null;

            try
            {
                Tag? entity = await this._tagRepository.UpdateAsync(this._autoMapper.Map<Tag>(tag), cancellationToken).ConfigureAwait(false);
                tagModel = this._autoMapper.Map<TagModel>(entity);
            }
            catch
            {
                throw;
            }

            return tagModel;
        }

        /// <inheritdoc/>
        public async Task<TagModel?> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            TagModel? tagModel = null;

            try
            {
                Tag? entity = await this._tagRepository.GetAsync(tag => tag.Id.Equals(id), cancellationToken).ConfigureAwait(false);
                await this._tagRepository.DeleteAsync(this._autoMapper.Map<Tag>(entity), cancellationToken).ConfigureAwait(false);
                tagModel = this._autoMapper.Map<TagModel>(entity);
            }
            catch
            {
                throw;
            }

            return tagModel;
        }

        /// <inheritdoc/>
        public async Task<bool> ShortCodeExistsAsync(string code, CancellationToken cancellationToken)
        {
            bool shortCodeExists = false;

            try
            {
                shortCodeExists = await this._tagRepository.ExistsAsync(tag => tag.Code.Equals(code, StringComparison.OrdinalIgnoreCase) && !tag.IsDeleted, cancellationToken);
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
                longUrlExists = await this._tagRepository.ExistsAsync(tag => tag.Url.Equals(url, StringComparison.OrdinalIgnoreCase) && !tag.IsDeleted, cancellationToken);
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
                Tag? entity = await this._tagRepository.GetAsync(tag => tag.Url == url && !tag.IsDeleted, cancellationToken).ConfigureAwait(false);
                return entity?.Code ?? string.Empty;
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
                Tag? entity =
                    await this._tagRepository.GetAsync(tag => tag.Code.Equals(code, StringComparison.OrdinalIgnoreCase) && !tag.IsDeleted, cancellationToken).ConfigureAwait(false);
                return entity?.Url ?? string.Empty;
            }
            catch
            {
                throw;
            }
        }
    }
}
