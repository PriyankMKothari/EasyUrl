namespace UrlShortener.Application;

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
        
    /// <summary>
    /// Gets or sets the date and time of the URL creation
    /// </summary>
    public DateTime CreatedAt { get; set; }
        
    /// <summary>
    /// Gets or sets the count of the clicks
    /// </summary>
    public int Count { get; set; }
}