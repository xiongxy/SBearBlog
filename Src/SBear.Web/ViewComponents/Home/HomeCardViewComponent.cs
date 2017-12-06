using Microsoft.AspNetCore.Mvc;
using SBear.Web.ViewModels;
namespace SBear.Web.ViewComponents.Home
{
    public class HomeCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(CardViewModel cardViewModel)
        {
            return View(cardViewModel);
        }
    }
    public enum CardAciotnTypeEnum
    {
        AtricleEdit = 1,
        HomeIndex = 2,
        HomeSearch = 3
    }
}
