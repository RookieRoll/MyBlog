using System;
using System.Collections.Generic;

namespace MyBlog.EntityFrameWorkCore.Models
{
    public partial class Classification
    {
        public Classification()
        {
            ClassifyBlog = new HashSet<ClassifyBlog>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public DateTime? ModificationDate { get; set; }

        public virtual ICollection<ClassifyBlog> ClassifyBlog { get; set; }

        public Classification(string content)
        {
            Content = content;
            IsDeleted = false;
            CreationTime = DateTime.Now;
        }
    }
}
