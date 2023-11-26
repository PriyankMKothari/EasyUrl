using UrlShortener.Application;
using UrlShortner.Services.Models;

namespace UrlShortener.Services
{
    /// <summary>
    /// Implementation of <see cref="IUrlShortenerService" />.
    /// </summary>
    public sealed class UrlShortenerService : IUrlShortenerService
    {
        private readonly IDatabaseService _databaseService;
        private readonly ICodeService _codeService;

        /// <summary>
        /// Initiates a new instance of <see cref="UrlShortenerService" />.
        /// </summary>
        /// <param name="databaseService"><see cref="IDatabaseService" />.</param>
        /// <param name="codeGeneratorService"><see cref="ICodeService" />.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UrlShortenerService(IDatabaseService databaseService, ICodeService codeGeneratorService)
        {
            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
            _codeService = codeGeneratorService ?? throw new ArgumentNullException(nameof(codeGeneratorService));
        }

        /// <inheritdoc />
        public async Task<ITagModel> GenerateShortCodeAsync(string url, CancellationToken cancellationToken)
        {
            string code = await this._codeService.GenerateHashCodeAsync(url, 10).ConfigureAwait(false);

            TagModel tagModel = await _databaseService.CreateAsync(new TagModel { Code = code, Url = url }, cancellationToken).ConfigureAwait(false);

            return await Task.FromResult(tagModel);
        }

        /// <inheritdoc />
        public async Task<ITagModel> GetShortCodeAsync(string url, CancellationToken cancellationToken)
        {
            string? code = await this._databaseService.GetShortCodeAsync(url, cancellationToken).ConfigureAwait(false);

            TagModel tagModel = new TagModel { Code = code ?? string.Empty, Url = url ?? string.Empty };

            return await Task.FromResult(tagModel);
        }

        /// <inheritdoc />
        public async Task<ITagModel> GetLongUrlAsync(string code, CancellationToken cancellationToken)
        {
            string? url = await this._databaseService.GetLongUrlAsync(code, cancellationToken).ConfigureAwait(false);

            TagModel tagModel = new TagModel { Code = code ?? string.Empty, Url = url ?? string.Empty };

            return await Task.FromResult(tagModel);
        }
    }
}
