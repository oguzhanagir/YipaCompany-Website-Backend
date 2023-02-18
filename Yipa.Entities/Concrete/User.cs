using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yipa.Entities.Concrete
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Mail { get; set; }
        public string? Password { get; set; }

#pragma warning disable CS8618 // Non-nullable property 'Blogs' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public List<Blog> Blogs { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Blogs' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
