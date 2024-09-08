using UrlShortener.Application;

namespace UrlShortener.Services.Models;

/// <inheritdoc />
public sealed class TagModel : ITagModel
{
    /// <inheritdoc />
    public string Code { get; set; } = string.Empty;

    /// <inheritdoc />
    public string Url { get; set; } = string.Empty;

    /// <inheritdoc />
    public DateTime CreatedAt { get; set; } = DateTime.Now.ToLocalTime();
        
    /// <inheritdoc />
    public int Count { get; set; }
}