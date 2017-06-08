using System;
using System.Collections.Generic;

namespace MyBlog.EntityFrameWorkCore.Models
{
    public partial class Blog
    {
        public Blog()
        {
            ClassifyBlog = new HashSet<ClassifyBlog>();
        }

        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public int State { get; set; }

        public virtual ICollection<ClassifyBlog> ClassifyBlog { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual Admin Author { get; set; }
    }
}
