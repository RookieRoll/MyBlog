using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UEditorNetCore;
using MyBlog.Application.ClassificationApplicationService;
using MyBlog.AdminBlog.ViewModel.Blogs;
using MyBlog.Application.BlogsApplicationService;
using MyBlog.EntityFrameWorkCore.Models;
using MyBlog.Core;

namespace MyBlog.AdminBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly UEditorService _ue;
        private readonly IClassificationApplicationService _classService;
        private readonly IBlogsApplicationService _blogService;
        public BlogController(
            UEditorService ue,
            IClassificationApplicationService classService,
            IBlogsApplicationService blogService)
        {
            _ue = ue;
            _classService = classService;
            _blogService = blogService;
        }

        #region 未发表
        public IActionResult UnPublish()
        {
            Func<Blog, bool> func = state => state.State == (int)BlogStates.Unpublish;

            var result = _blogService.Get(func)
                .Select(m => BlogViewModel
                .Convert(m.Id, m.Title, m.CreationTime, m.ModificationTime));
            return View(result);
        }

        public IActionResult Update(int id)
        {
            var blog = _blogService.Get(id);
            var classifyList = _classService.Get();
            var result = EditViewModel.Convert(blog.Id, blog.Title, blog.Content, blog.ClassifyId);
            result.ClassifyList = classifyList.Select(m=> ClassifyContent.Convert(m.Id,m.Content));
            return View("_Update",result);
        }
        #endregion

        public IActionResult Create()
        {
            var classify = _classService.Get()
                .Select(m => ClassifyContent.Convert(m.Id, m.Content));
            return View("_Create", classify);
        }

        [HttpPost]
        public IActionResult CreateConfirm(CreateViewModel model)
        {
            _blogService.Create(model.ClassifId, model.Title, model.Content, 1, "Kobold");
            return RedirectToAction("UnPublish");
        }


        //UEditor操作
        public void UEditorAction()
        {
            _ue.DoAction(HttpContext);
        }
    }
}