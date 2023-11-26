namespace UrlShortener.Persistent.Entities
{
    public sealed class Tag
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }

        public DateTimeOffset DeletedDate { get; set; }
    }
}
