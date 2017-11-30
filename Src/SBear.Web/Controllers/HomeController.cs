using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SBear.Service.Blog.IBlogService;
using SBear.Web.ViewModels;

namespace SBear.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogUserService _blogUserService;
        public HomeController(IBlogUserService blogUserService)
        {
            _blogUserService = blogUserService;
        }

        public IActionResult Index()
        {
            var v = _blogUserService.GetUser("admin");
            return View();
        }
    }
}
