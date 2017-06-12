using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.AdminBlog.ViewModel.Classifications
{
    public class UpdateViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public static UpdateViewModel Convert(int id,string content)
        {
            return new UpdateViewModel
            {
                Id = id,
                Content = content
            };
        }
    }
}
