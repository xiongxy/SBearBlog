using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SBear.Service.Blog.IBlogService;
using SBear.Web.ViewModels.AccountViewModel;

namespace SBear.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IBlogUserService _blogUserService;
        public RegisterController(IBlogUserService blogUserService)
        {
            _blogUserService = blogUserService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var v = _blogUserService.Insert(vm.UserName, vm.Password);
            if (v)
            {
                return RedirectToAction("Index", "Login");
            }
            ModelState.AddModelError("UserName", "账号已经存在，请重新选择用户名进行注册！");
            return View(vm);
        }
    }
}
