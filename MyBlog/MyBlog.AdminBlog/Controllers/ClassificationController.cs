using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.ClassificationApplicationService;
using MyBlog.AdminBlog.ViewModel.Classifications;

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
            var result = _classifyService.Get()
                .Select(m => ClassificationViewModel
                .Convert(m.Id, m.Content, m.CreationTime, m.ModificationDate));
            return View(result);
        }

        [HttpPost]
        public IActionResult Create(string content)
        {
            _classifyService.Create(content);
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var data = _classifyService.Get(id);
            var result = DeleteViewModel.Convert(data.Id, data.Content);
            return View("_Delete", result);
        }
        [HttpPost]
        public IActionResult DeleteComfirm(int id)
        {
            _classifyService.Remove(id);
            return View("_SuccessInfo");
        }
        [HttpPost]
        public IActionResult Update(int id)
        {
            var data = _classifyService.Get(id);
            var result = UpdateViewModel.Convert(data.Id, data.Content);
            return View("_Update", result);
        }
        [HttpPost]
        public IActionResult UpdateConfirm(UpdateViewModel update)
        {
            _classifyService.Update(update.Id, update.Content);
            return RedirectToAction("index");
        }
    }
}