using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.AdminBlog.Areas.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Test")]
    public class TestController : BaseController
    {
        [HttpGet("get")]
        public JsonResult Test()
        {
            return Json("这是一个测试");
        }
    }
}