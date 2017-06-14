using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.AdminBlog.ViewModel.Blogs
{
    public class DeleteViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public static DeleteViewModel Convert(int id,string title)
        {
            return new DeleteViewModel
            {
                Id = id,
                Title = title
            };
        }
    }
}
