using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SBear.Framework.Account;
using SBear.Service.Blog.IBlogService;
using SBear.Web.ViewModels.AccountViewModel;

namespace SBear.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IBlogUserService _blogUserService;
        public LoginController(IBlogUserService blogUserService)
        {
            _blogUserService = blogUserService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginViewModel vm)
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
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
