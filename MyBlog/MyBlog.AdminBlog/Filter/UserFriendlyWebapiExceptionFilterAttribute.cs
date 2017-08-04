using Microsoft.AspNetCore.Mvc.Filters;
using MyBlog.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.AdminBlog.Filter
{
    public class UserFriendlyWebapiExceptionFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var originalException = context.Exception;
            UserFriendlyException ex = null;
            if (originalException is UserFriendlyException)
                ex = originalException as UserFriendlyException;
            else
                ex = new UserFriendlyException(originalException.Message, errorCode: "");

            context.HttpContext.Response.StatusCode =(int)ex.HttpStatus;
            MemoryStream mStrm = new MemoryStream(Encoding.UTF8.GetBytes("出现了错误"));
            context.HttpContext.Response.Body = mStrm;
           
            base.OnException(context);
        }
    }
}
