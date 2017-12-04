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
    public enum AciotnType
    {
        Edit = 1,
        Home = 2,
    }
}
