using EasyUrl.Application.Models;

namespace EasyUrl.Services.Models;

public sealed class ClickModel : IClickModel
{
    /// <summary>
    /// Gets Id of the click.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Gets or sets IP address of the click.
    /// </summary>
    public string IpAddress { get; init; }
    
    /// <summary>
    /// Gets or sets user agent details of the click.
    /// </summary>
    public string UserAgent { get; init; }
    
    /// <summary>
    /// Gets or sets device type of the click.
    /// </summary>
    public string DeviceType { get; init; }
    
    /// <summary>
    /// Gets or sets browser details of the click.
    /// </summary>
    public string Browser { get; init; }
    
    /// <summary>
    /// Gets or sets country, based on the IP address.
    /// </summary>
    public string Country { get; init; }
    
    /// <summary>
    /// Gets created date of the click.
    /// </summary>
    public DateTimeOffset CreatedAt { get; init; }
    
    /// <summary>
    /// Gets or sets the Id of the EasyUrl.
    /// </summary>
    public int EasyUrlId { get; init; }

    /// <summary>
    /// Gets or sets the <see cref="IEasyUrlModel" />.
    /// </summary>
    public IEasyUrlModel? EasyUrlModel { get; init; }
}