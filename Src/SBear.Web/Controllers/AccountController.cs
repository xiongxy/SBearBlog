using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBear.Service.Blog.IBlogService;
using SBear.Web.ViewModels.AccountViewModel;
using SBear.Framework;
using SBear.Framework.Account;
using Newtonsoft.Json;

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
                UserRuntimeInfo userRuntimeInfo = new UserRuntimeInfo()
                {
                    NickName = v.Nickname,
                    UserName = v.UserName
                };
                UserRuntimeContext.CurrentUser = userRuntimeInfo;
                return Redirect("../Home/Index");
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
            if (v != null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return Redirect("../Home/Index");
        }
    }
}