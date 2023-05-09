namespace Yipa.Entities.Concrete
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Mail { get; set; }
        public DateTime? PublishDate { get; set; }

        public int BlogId { get; set; }
        public Blog? Blog { get; set; }
    }
}
