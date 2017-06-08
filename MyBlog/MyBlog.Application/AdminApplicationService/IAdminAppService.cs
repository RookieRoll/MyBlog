using MyBlog.EntityFrameWorkCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Application.AdminApplicationService
{
    public interface IAdminAppService
    { /// <summary>
      /// 管理员登录
      /// </summary>
      /// <param name="username"></param>
      /// <param name="password"></param>
      /// <returns></returns>
        User Login(string username, string password);
    }
}
