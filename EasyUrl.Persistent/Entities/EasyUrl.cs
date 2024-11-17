namespace EasyUrl.Persistent.Entities;

/// <summary>
/// Model representing a tag entity.
/// </summary>
public class EasyUrl
{
    /// <summary>
    /// Gets or sets id.
    /// </summary>
    public int Id { get; private set; }
    
    /// <summary>
    /// Gets or sets original url.
    /// </summary>
    public string OriginalUrl { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets short url.
    /// </summary>
    public string ShortUrl { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets custom alias.
    /// </summary>
    public string CustomAlias { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets created date.
    /// </summary>
    public DateTimeOffset CreatedDate { get; private set; }
    
    /// <summary>
    /// Gets or sets modified date.
    /// </summary>
    public DateTimeOffset? ModifiedDate { get; private set; }
    
    /// <summary>
    /// Gets or sets deleted date.
    /// </summary>
    public DateTimeOffset? DeletedDate { get; private set; }
    
    /// <summary>
    /// Gets or sets expiration date.
    /// </summary>
    public DateTimeOffset? ExpirationDate { get; set; }

    /// <summary>
    /// Gets or sets is deleted.
    /// </summary>
    public bool IsDeleted { get; set; } = false;
    
    /// <summary>
    /// Gets or sets clicks count.
    /// </summary>
    public int ClicksCount { get; set; } = 0;
    
    /// <summary>
    /// Gets or sets custom domain.
    /// </summary>
    public string? CustomDomain { get; set; }
    
    /// <summary>
    /// Gets or sets <see cref="ICollection{T}" /> of <see cref="Entities.Click" />s.
    /// </summary>
    public virtual ICollection<Click>? Clicks { get; set; }
}