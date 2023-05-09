namespace Yipa.Entities.Concrete
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Mail { get; set; }
        public string? Password { get; set; }
        public bool KeepLoggedIn { get; set; }

        public List<Blog>? Blogs { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
