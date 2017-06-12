using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UEditorNetCore;
using MyBlog.Application.ClassificationApplicationService;
using MyBlog.AdminBlog.ViewModel.Blogs;

namespace MyBlog.AdminBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly UEditorService _ue;
        private readonly IClassificationApplicationService _classService;
        public BlogController(UEditorService ue,
            IClassificationApplicationService classService)
        {
            _ue = ue;
            _classService = classService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var classify = _classService.Get()
                .Select(m => ClassifyContent.Convert(m.Id, m.Content));
            return View(classify);
        }

        public IActionResult CreateConfirm()
        {
            return View();
        }


        //UEditor操作
        public void UEditorAction()
        {
            _ue.DoAction(HttpContext);
        }
    }
}