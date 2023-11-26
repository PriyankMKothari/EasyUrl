namespace UrlShortener.Application
{
    /// <summary>
    /// Represents the shortened code for the long url.
    /// </summary>
    public interface ITagModel
    {
        /// <summary>
        /// Gets or sets the shortened code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the long url.
        /// </summary>
        public string Url { get; set; }
    }
}
