using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.AdminBlog.ViewModel.Blogs
{
    public class ClassifyContent
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public static ClassifyContent Convert(int id,string content)
        {
            return new ClassifyContent {
                Id=id,
                Content=content
            };
            
        }
    }
}
