using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBear.Service.Blog.IBlogService;
using SBear.Web.ViewModels.AccountViewModel;


namespace SBear.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IBlogUserService _blogUserService;
        public AccountController(IBlogUserService blogUserService)
        {
            _blogUserService = blogUserService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var v = _blogUserService.CheckUser(vm.UserName, vm.Password);
            if (v != null)
            {
                HttpContext.Session.SetString("LoginMessage", $"{v.Nickname}|{v.UserName}|{vm.Password}");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var v = _blogUserService.Insert(vm.UserName, vm.Password);
            return View();
        }
    }
}