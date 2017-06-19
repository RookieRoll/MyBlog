using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.ClassificationApplicationService;
using MyBlog.AdminBlog.Areas.Api.Dtos;

namespace MyBlog.AdminBlog.Areas.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Classify")]
    public class ClassifyController : BaseController
    {
        private readonly IClassificationApplicationService _classifyService;

        public ClassifyController(IClassificationApplicationService classifyService)
        {
            _classifyService = classifyService;
        }

        [HttpGet("Get")]
        public JsonResult Get()
        {
            var result = _classifyService.Get().Select(m => new ClassifyDto
            {
                Id=m.Id,
                Content=m.Content
            });
            return Json(result);
        }
    }
}