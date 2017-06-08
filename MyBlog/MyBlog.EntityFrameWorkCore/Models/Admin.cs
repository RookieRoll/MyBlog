using System;
using System.Collections.Generic;

namespace MyBlog.EntityFrameWorkCore.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Blog = new HashSet<Blog>();
        }

        public int UserId { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Blog> Blog { get; set; }
        public virtual User User { get; set; }
    }
}
