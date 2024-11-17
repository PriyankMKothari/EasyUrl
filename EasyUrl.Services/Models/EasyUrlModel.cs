using System.ComponentModel.DataAnnotations;
using EasyUrl.Application.Models;

namespace EasyUrl.Services.Models;

/// <summary>
/// Represents an Easy Url model.
/// </summary>
public sealed class EasyUrlModel : IEasyUrlModel
{
    /// <summary>
    /// Gets id of the EasyUrl.
    /// </summary>
    public int Id { get; init; }
    
    /// <summary>
    /// Gets or sets original url.
    /// </summary>
    [MaxLength(2000)]
    public string OriginalUrl { get; init; }
    
    /// <summary>
    /// Gets shortened url.
    /// </summary>
    public string ShortUrl { get; init; }
        
    /// <summary>
    /// Gets or sets custom alias.
    /// </summary>
    public string CustomAlias { get; init; }
    
    /// <summary>
    /// Gets custom domain.
    /// </summary>
    public string? CustomDomain { get; init; }

    /// <summary>
    /// Gets expiration date.
    /// </summary>
    public DateTimeOffset? ExpirationDate { get; init; }
    
    /// <summary>
    /// Gets created date.
    /// </summary>
    public DateTimeOffset CreatedDate { get; init; }

    /// <summary>
    /// Gets modified date.
    /// </summary>
    public DateTimeOffset? ModifiedDate { get; init; }
    
    /// <summary>
    /// Gets deleted date.
    /// </summary>
    public DateTimeOffset? DeletedDate { get; init; }

    /// <summary>
    /// Gets is deleted.
    /// </summary>
    public bool IsDeleted { get; init; }
}