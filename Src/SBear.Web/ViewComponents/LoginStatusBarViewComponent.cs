using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SBear.Web.ViewComponents
{
    public class LoginStatusBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
