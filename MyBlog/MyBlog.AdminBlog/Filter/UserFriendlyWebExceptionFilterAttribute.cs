using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.AdminBlog.Filter
{
    public class UserFriendlyWebExceptionFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var originalException = context.Exception;
            UserFriendlyException ex = null;
            if (originalException is UserFriendlyException)
                ex = originalException as UserFriendlyException;
            else
                ex = new UserFriendlyException(originalException.Message, errorCode: "");

            context.ExceptionHandled = true;
            int status = 500;
            string msg = "服务器正忙";
            if(ex!=null)
            {
                status = (int)ex.HttpStatus;
                msg = ex.Message;
            }
            if(context.HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
            {
                context.Result = new RedirectResult("/Home/Error");
            }
            else
            {
                context.Result = new ContentResult {Content=msg };
            }
        }
    }
}
