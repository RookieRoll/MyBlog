using System;
using System.Collections.Generic;

namespace MyBlog.EntityFrameWorkCore.Models
{
    public partial class ClassifyBlog
    {
        public int BlogId { get; set; }
        public int ClassifyId { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual Classification Classify { get; set; }
    }
}
