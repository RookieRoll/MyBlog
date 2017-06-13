using MyBlog.Core;
using MyBlog.Core.Blogs;
using MyBlog.EntityFrameWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MyBlog.Application.BlogsApplicationService
{
    public class BlogsApplicationService : IBlogsApplicationService
    {
        private readonly BlogManager _blogManager;
        private readonly MyBlogContext _db;

        public BlogsApplicationService(BlogManager blogManager,
            MyBlogContext db)
        {
            _blogManager = blogManager;
            _db = db;
        }

        public IQueryable<Blog> Get()
        {
            return _blogManager.Get().Where(m => !m.IsDeleted);
        }

        public IQueryable<Blog> Get(Func<Blog,bool> func)
        {
            return Get().Where(func).AsParallel().AsQueryable();
        }
        public void Create(int classifyId,string title,string content,int authorId,string authorName)
        {
            _blogManager.Create(Blog.Convert(classifyId,content,title,authorId,authorName,(int)BlogStates.Unpublish));
        }
        public Blog Get(int id)
        {
            var blog = Get().AsParallel().FirstOrDefault(m => m.Id == id);
            return blog ?? throw new UserFriendlyException("该博文不存在", HttpStatusCode.BadRequest);

        }

        public void Remove(int id)
        {
            var date = Get(id);
            _blogManager.Remove(id);
        }
    }
}
