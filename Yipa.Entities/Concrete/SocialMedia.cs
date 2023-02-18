using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yipa.Entities.Concrete
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? IconPath { get; set; }
        public string? Address { get; set; }
    }
}
