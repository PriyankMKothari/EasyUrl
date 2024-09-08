namespace UrlShortener.Persistent.Entities;

public sealed class Tag
{
    public int Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public DateTimeOffset CreatedDate { get; set; }
}