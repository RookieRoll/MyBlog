using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.AdminBlog.ViewModel.Classifications
{
    public class DeleteViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public static DeleteViewModel Convert(int id,string content)
        {
            return new DeleteViewModel
            {
                Id = id,
                Content = content
            };
        }
    }
}
