﻿namespace Yipa.Entities.Concrete
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Blog>? Blogs { get; set; }
    }
}
