using System;
using System.Collections.Generic;

namespace MyBlog.EntityFrameWorkCore.Models
{
    public partial class User
    {
        public User()
        {
            Admin = new HashSet<Admin>();
            Customer = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Admin> Admin { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
    }
}
