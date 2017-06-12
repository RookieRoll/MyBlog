using System;
using System.Collections.Generic;

namespace MyBlog.EntityFrameWorkCore.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Comment = new HashSet<Comment>();
        }

        public int? UserId { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual User User { get; set; }
    }
}
