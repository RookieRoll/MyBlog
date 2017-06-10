using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.AdminBlog.Navigation
{
    public class MenuItem
    {
        public MenuItem()
        {
            Children = new List<MenuItem>();
        }

        public string RequiredAuthorizeCode { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<MenuItem> Children { get; set; }

        public bool HasChild
        {
            get { return Children.Count > 0; }
        }
    }
}
