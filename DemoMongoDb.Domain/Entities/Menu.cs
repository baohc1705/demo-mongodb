namespace DemoMongoDb.Domain.Entities
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? Url { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
