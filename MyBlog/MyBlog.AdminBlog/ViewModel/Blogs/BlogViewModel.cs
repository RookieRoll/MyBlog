using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.AdminBlog.ViewModel.Blogs
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreateTime { get; set; }
        public string ModificationTime { get; set; }

        public static BlogViewModel Convert(int id,string title,DateTime creationTime,DateTime? modificationTime)
        {
            return new BlogViewModel
            {
                Id = id,
                Title = title,
                CreateTime = creationTime.ToString("yyyy-MM-dd HH:mm"),
                ModificationTime = modificationTime.Value.ToString("yyyy-MM-dd HH:mm")
            };
        }
    }
}
