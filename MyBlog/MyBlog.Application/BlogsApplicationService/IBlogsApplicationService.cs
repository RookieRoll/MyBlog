using MyBlog.EntityFrameWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Application.BlogsApplicationService
{
    public interface IBlogsApplicationService
    {
        IQueryable<Blog> Get();
        IQueryable<Blog> Get(Func<Blog, bool> func);
        void Create(int classifyId, string title, string content, int authorId, string authorName);
        Blog Get(int id);
        void Remove(int id);
    }
}
