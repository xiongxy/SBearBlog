using Microsoft.AspNetCore.Mvc;
using SBear.Service.SBear.ISBearService;
using SBear.Web.ViewModels.HomeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBear.Web.ViewComponents.Home
{
    public class HomeSideBarViewComponent : ViewComponent
    {
        private ISBearVisitorLogService _iSBearVisitorLogService;
        public HomeSideBarViewComponent(ISBearVisitorLogService iSBearVisitorLogService)
        {
            _iSBearVisitorLogService = iSBearVisitorLogService;
        }
        public IViewComponentResult Invoke(HomeSideBarViewModel vm)
        {
            return View(vm);
        }
    }
}
