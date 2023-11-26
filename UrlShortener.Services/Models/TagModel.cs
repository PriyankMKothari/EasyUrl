using UrlShortener.Application;

namespace UrlShortner.Services.Models
{
    /// <inheritdoc />
    public sealed class TagModel : ITagModel
    {
        /// <inheritdoc />
        public string Code { get; set; } = string.Empty;

        /// <inheritdoc />
        public string Url { get; set; } = string.Empty;
    }
}
