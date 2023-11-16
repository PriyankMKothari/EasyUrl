namespace UrlShortner.Services.Models
{
    /// <summary>
    /// Represents the shortened code for the long url.
    /// </summary>
    public sealed class TagModel
    {
        /// <summary>
        /// Gets or sets the shortened code.
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the long url.
        /// </summary>
        public string Url { get; set; } = string.Empty;
    }
}
