using System;
using System.Collections.Generic;

namespace MyBlog.EntityFrameWorkCore.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }
        public DateTime PublishTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }

        public virtual Customer Author { get; set; }
        public virtual Blog IdNavigation { get; set; }
    }
}
