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

        public void Create(Blog blog)
        {
            _db.Blog.Add(blog);
            _db.SaveChanges();
        }

        public void Update(int id, string content, string title,int classifiId,string subcontent)
        {
            var blog = _db.Blog.AsParallel().FirstOrDefault(m => m.Id == id);
            blog.Title = title;
            blog.Content = content;
            blog.ModificationTime = DateTime.Now;
            blog.ClassifyId = classifiId;
            blog.SubContent = subcontent;
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

        public void SetBlogState(int id,BlogStates state)
        {
            var blog = Get().FirstOrDefault(m=>m.Id==id);
            blog.State = (int)state;
            blog.ModificationTime = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
