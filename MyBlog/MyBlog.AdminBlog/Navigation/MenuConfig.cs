using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.AdminBlog.Navigation
{
    public class MenuConfig
    {
        public static MenuItem SideMenu { get; set; } = new MenuItem();

        static MenuConfig()
        {
            SideMenu = new MenuItem();
      
            //创建用户相关的权限
            MenuItem item = new MenuItem { Name = "用户", Url = "/Blog/Create"};
            SideMenu.Children.Add(item);
            //创建权限相关的菜单
            item = new MenuItem { Name = "分类", Url = "/Classification/Index" };
            SideMenu.Children.Add(item);
            //创建组织相关的菜单
            item = new MenuItem { Name = "博客"};
            item.Children.Add(new MenuItem { Name="未发表博文",Url="/Blog/UnPublish"});
            item.Children.Add(new MenuItem { Name = "已发表博文" });
            SideMenu.Children.Add(item);
        }
    }
}
