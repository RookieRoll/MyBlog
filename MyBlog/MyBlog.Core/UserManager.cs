using MyBlog.EntityFrameWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Core
{
    public class UserManager
    {
        private readonly MyBlogContext _db;

        public UserManager(MyBlogContext db)
        {
            _db = db;
        }
        public IQueryable<User> Gets()
        {
            return _db.User;
        }
    }
}