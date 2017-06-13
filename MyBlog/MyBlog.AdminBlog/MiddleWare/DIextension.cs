using Microsoft.Extensions.DependencyInjection;
using MyBlog.Application.AdminApplicationService;
using MyBlog.Application.BlogsApplicationService;
using MyBlog.Application.ClassificationApplicationService;
using MyBlog.Core;
using MyBlog.Core.Blogs;
using MyBlog.Core.Classifications;
using MyBlog.EntityFrameWorkCore.Models;

namespace MyBlog.AdminBlog.MiddleWare
{
    public static class DIextension
    {
        public static void AddDi(this IServiceCollection services)
        {
            services.AddDbContext<MyBlogContext>();
            services.AddScoped<UserManager>();
            services.AddScoped<IAdminAppService, AdminAppService>();
            services.AddScoped<ClassificationManager>();
            services.AddScoped<IClassificationApplicationService, ClassificationAppLicationService>();
            services.AddScoped<BlogManager>();
            services.AddScoped<IBlogsApplicationService,BlogsApplicationService>();
        }
    }
}
