using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UEditorNetCore;

namespace MyBlog.AdminBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly UEditorService _ue;
        public BlogController(UEditorService ue)
        {
            _ue = ue;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public void UEditorAction()
        {
            _ue.DoAction(HttpContext);
        }
    }
}