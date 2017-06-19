using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.BlogsApplicationService;
using MyBlog.EntityFrameWorkCore.Models;
using MyBlog.Core;
using Newtonsoft.Json;

namespace MyBlog.AdminBlog.Areas.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/blogs")]
    public class BlogsController : BaseController
    {
        private readonly IBlogsApplicationService _blogService;

        public BlogsController(IBlogsApplicationService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("get/{id}")]
        public JsonResult Get(int id)
        {
            Func<Blog, bool> func = blog => !blog.IsDeleted && blog.State == (int)BlogStates.Publish && blog.ClassifyId == id;
            var result = _blogService.Get(func).AsParallel();
            return Json(result);
        }

        [HttpGet("detail/{id}")]
        public JsonResult Detail(int id)
        {
            var blog = _blogService.Get(id);
            var test = JsonConvert.SerializeObject(blog);
            return Json(blog);
        }
    }
}