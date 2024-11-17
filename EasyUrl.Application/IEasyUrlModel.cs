using System.ComponentModel.DataAnnotations;

namespace EasyUrl.Application.Models;

/// <summary>
/// Represents the shortened code for the long url.
/// </summary>
public interface IEasyUrlModel
{
    /// <summary>
    /// Gets id of the EasyUrl.
    /// </summary>
    int Id { get; init; }
    
    /// <summary>
    /// Gets or sets original url.
    /// </summary>
    [MaxLength(2000)]
    string OriginalUrl { get; init; }
    
    /// <summary>
    /// Gets shortened url.
    /// </summary>
    string ShortUrl { get; init; }
        
    /// <summary>
    /// Gets or sets custom alias.
    /// </summary>
    string CustomAlias { get; init; }
    
    /// <summary>
    /// Gets custom domain.
    /// </summary>
    string? CustomDomain { get; init; }
    
    /// <summary>
    /// Gets expiration date.
    /// </summary>
    DateTimeOffset? ExpirationDate { get; init; }

    /// <summary>
    /// Gets created date.
    /// </summary>
    DateTimeOffset CreatedDate { get; init; }

    /// <summary>
    /// Gets modified date.
    /// </summary>
    DateTimeOffset? ModifiedDate { get; init; }
    
    /// <summary>
    /// Gets deleted date.
    /// </summary>
    DateTimeOffset? DeletedDate { get; init; }

    /// <summary>
    /// Gets is deleted.
    /// </summary>
    bool IsDeleted { get; init; }
}