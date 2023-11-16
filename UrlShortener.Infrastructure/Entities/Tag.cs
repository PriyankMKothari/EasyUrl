namespace UrlShortener.Persistent.Entities
{
    public sealed class Tag
    {
        public int Id { get; set; }

        public string ShortCode { get; set; } = string.Empty;

        public string LongUrl { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
