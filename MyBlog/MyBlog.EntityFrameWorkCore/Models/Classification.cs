using System;
using System.Collections.Generic;

namespace MyBlog.EntityFrameWorkCore.Models
{
    public partial class Classification
    {
        public Classification()
        {
            Blog = new HashSet<Blog>();
        }

        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
        public DateTime? ModificationTime { get; set; }

        public virtual ICollection<Blog> Blog { get; set; }

        public static Classification Convert(string content)
        {
            return new Classification
            {
                IsDeleted=false,
                CreationTime=DateTime.Now,
                ModificationTime=DateTime.Now,
                Content=content

            };
        }
    }
}
