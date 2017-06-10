using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.ClassificationApplicationService;

namespace MyBlog.AdminBlog.Controllers
{
    public class ClassificationController : Controller
    {
        private readonly IClassificationApplicationService _classifyService;

        public ClassificationController(IClassificationApplicationService classifyService)
        {
            _classifyService = classifyService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string content)
        {
            _classifyService.Create(content);
            return View("index");
        }
    }
}