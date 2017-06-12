using System;
using System.Collections.Generic;

namespace MyBlog.EntityFrameWorkCore.Models
{
    public partial class Blog
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public int State { get; set; }
        public int ClassifyId { get; set; }
        public int Id { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual Admin Author { get; set; }
        public virtual Classification Classify { get; set; }
    }
}
