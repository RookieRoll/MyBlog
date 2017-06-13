using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.AdminBlog.ViewModel.Blogs
{
    public class EditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int ClassifyId { get; set; }

        public IEnumerable<ClassifyContent> ClassifyList { get; set; }

        public static EditViewModel Convert(int id,string title,string content,int classified)
        {
            return new EditViewModel
            {
                Id = id,
                Title = title,
                Content = content,
                ClassifyId = classified
            };
        }
    }
}
