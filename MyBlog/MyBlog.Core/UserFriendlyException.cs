using System;
using System.Net;

namespace MyBlog.Core
{
    public class UserFriendlyException:Exception
    {
        public HttpStatusCode HttpStatus { get; } = HttpStatusCode.InternalServerError;

        public string ErrorCode { get; }

        public UserFriendlyException(string message, HttpStatusCode httpStatus = HttpStatusCode.InternalServerError, string errorCode = null)
            : base(message)
        {
            HttpStatus = httpStatus;
            ErrorCode = errorCode;
        }
    }
}
