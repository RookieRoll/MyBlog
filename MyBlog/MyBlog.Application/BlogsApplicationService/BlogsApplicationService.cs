using MyBlog.Core;
using MyBlog.Core.Blogs;
using MyBlog.EntityFrameWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

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
            Func<Blog, bool> func = m => !m.IsDeleted;
            return Get(func);
        }

        public IQueryable<Blog> Get(Func<Blog,bool> func)
        {
            return _blogManager.Get().Where(func).AsParallel().AsQueryable();
        }
        public void Create(int classifyId,string title,string content,int authorId,string authorName,string subcontent)
        {
            var newcontent = content.Replace("/upload", "http://localhost:63321/upload");
            _blogManager.Create(Blog.Convert(classifyId, newcontent, title,authorId,authorName,(int)BlogStates.Unpublish,subcontent));
        }
        public void Update(int id,string title,string content,int classifyId,string subcontent)
        {
            var newcontent = content.Replace("/upload", "http://localhost:63321/upload");
            _blogManager.Update(id, newcontent, title,classifyId,subcontent);
        }


        public Blog Get(int id)
        {
            var blog = Get().AsParallel().FirstOrDefault(m => m.Id == id);
            return blog ?? throw new UserFriendlyException("该博文不存在", HttpStatusCode.BadRequest);

        }

        public void SetBlogState(int id,BlogStates state)
        {
            var result = Get(id);
            _blogManager.SetBlogState(result.Id,state);
        }
        public void Remove(int id)
        {
            var date = Get(id);
            _blogManager.Remove(id);
        }
    }
}
