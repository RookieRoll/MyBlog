using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.AdminApplicationService;
using MyBlog.Core;
using MyBlog.EntityFrameWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.AdminBlog.MiddleWare
{
    public static class DIextension
    {
        public static void AddDi(this IServiceCollection services)
        {
            services.AddDbContext<MyBlogContext>();
            services.AddScoped<UserManager>();
            services.AddScoped<IAdminAppService, AdminAppService>();
            //services.AddScoped<MenuProvider>();
        }
    }
}
