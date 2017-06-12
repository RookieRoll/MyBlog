using System;
using System.Collections.Generic;

namespace MyBlog.EntityFrameWorkCore.Models
{
    public partial class Comment
    {
        public string AuthorName { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public int AuthorId { get; set; }
        public int Id { get; set; }

        public virtual Customer Author { get; set; }
        public virtual Blog IdNavigation { get; set; }
    }
}
