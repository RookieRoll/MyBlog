using Microsoft.AspNetCore.Mvc;
using MyBlog.AdminBlog.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.AdminBlog.ViewComponents.MenuViewComponets
{
    public class MenuViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result =await Task.FromResult(MenuConfig.SideMenu);

            return View("_Menu",result);
        }
    }
}
