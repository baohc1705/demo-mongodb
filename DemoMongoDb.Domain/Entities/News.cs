namespace DemoMongoDb.Domain.Entities
{
    public class News : BaseEntity
    {
        public string Title { get; set; } = default!;
        public string Slug { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string? Summary { get; set; }
        public string? Thumbnail { get; set; }
        public string? Author { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedAt { get; set; }
        public List<string> Tags { get; set; } = new();
    }
}
