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
using SBear.Web.Filters;

namespace SBear.Web.Controllers
{
    [CheckLoginAuthorize]
    public class AccountController : Controller
    {
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}