using MyBlog.EntityFrameWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Core.Blogs
{
    public class BlogManager
    {
        private readonly MyBlogContext _db;

        public BlogManager(MyBlogContext db)
        {
            _db = db;
        }

        public Blog Create(Blog blog)
        {
            _db.Blog.Add(blog);
            return blog;
        }

        public void Update(int id, string content, int title)
        {
            var blog = _db.Blog.AsParallel().FirstOrDefault(m => m.Id == id);

            blog.ModificationTime = DateTime.Now;
            _db.SaveChanges();
        }
        public IQueryable<Blog> Get()
        {
            return _db.Blog;
        }

        public void Remove(int id)
        {
            var blog = _db.Blog.AsParallel().FirstOrDefault(m => m.Id == id);
            blog.IsDeleted = true;
            blog.DeletionTime = DateTime.Now;
            blog.ModificationTime = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
