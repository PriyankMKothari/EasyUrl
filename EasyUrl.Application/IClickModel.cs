namespace EasyUrl.Application.Models;

public interface IClickModel
{
    /// <summary>
    /// Gets Id of the click.
    /// </summary>
    int Id { get; init; }

    /// <summary>
    /// Gets or sets IP address of the click.
    /// </summary>
    string IpAddress { get; init; }
    
    /// <summary>
    /// Gets or sets user agent details of the click.
    /// </summary>
    string UserAgent { get; init; }
    
    /// <summary>
    /// Gets or sets device type of the click.
    /// </summary>
    string DeviceType { get; init; }
    
    /// <summary>
    /// Gets or sets browser details of the click.
    /// </summary>
    string Browser { get; init; }
    
    /// <summary>
    /// Gets or sets country, based on the IP address.
    /// </summary>
    string Country { get; init; }
    
    /// <summary>
    /// Gets created date of the click.
    /// </summary>
    DateTimeOffset CreatedAt { get; init; }
    
    /// <summary>
    /// Gets or sets the Id of the EasyUrl.
    /// </summary>
    int EasyUrlId { get; init; }

    /// <summary>
    /// Gets or sets the <see cref="IEasyUrlModel" />.
    /// </summary>
    IEasyUrlModel? EasyUrlModel { get; init; }
}