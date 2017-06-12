using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.AdminBlog.ViewModel.Account;
using MyBlog.Application.AdminApplicationService;

namespace MyBlog.AdminBlog.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAdminAppService _appService;

        public AccountController(IAdminAppService appService)
        {
            _appService = appService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult LoginConfirm([FromForm]LoginViewModel login)
        {
            var user = _appService.Login(login.UserName, login.Password);
            if (user == null)
                return RedirectToAction("Login");
            return RedirectToAction("index", "Home");
        }
    }
}