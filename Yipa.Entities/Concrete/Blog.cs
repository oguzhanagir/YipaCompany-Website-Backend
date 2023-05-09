namespace Yipa.Entities.Concrete
{
    public class Blog
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? PublicDate { get; set; }

        public List<Comment>? Comments { get; set; }

        public int UserId { get; set; }


        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
