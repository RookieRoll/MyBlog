using MyBlog.Core;
using MyBlog.EntityFrameWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace MyBlog.Application.AdminApplicationService
{
    public class AdminAppService : IAdminAppService
    {
        private readonly UserManager _userManager;
        private readonly MyBlogContext _db;

        public AdminAppService(
            UserManager userManager,
            MyBlogContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public User Login(string username, string password)
        {
            var user = (from admins in _db.Admin
                        join users in _userManager.Gets() on admins.Id equals users.Id
                        where users.UserName.Equals(username)
                        && users.Password.Equals(password)
                        && !users.IsDeleted
                        select new User
                        {
                            Id = admins.Id,
                            IsDeleted = users.IsDeleted,
                            Birthday = users.Birthday,
                            CreationTime = users.CreationTime,
                            Email = users.Email,
                            Name = users.Name
                        }
                       ).FirstOrDefault();


            return user ?? throw new Exception("该用户不存在");
        }


    }
}