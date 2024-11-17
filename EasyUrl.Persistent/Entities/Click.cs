namespace EasyUrl.Persistent.Entities;

/// <summary>
/// Model representing a click on a easyUrl.
/// </summary>
public class Click
{
    /// <summary>
    /// Gets or sets the Id of the click.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the IP address of the click.
    /// </summary>
    public string IpAddress { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the user agent of the click.
    /// </summary>
    public string UserAgent { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the device type of the click.
    /// </summary>
    public string DeviceType { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the browser of the click.
    /// </summary>
    public string Browser { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the country of the click, based on the IP address.
    /// </summary>
    public string Country { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets created date of the click.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }
    
    /// <summary>
    /// Gets or sets the Id of the <see cref="Entities.EasyUrl" />.
    /// </summary>
    public int EasyUrlId { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="EasyUrl" />.
    /// </summary>
    public EasyUrl EasyUrl { get; set; }
}