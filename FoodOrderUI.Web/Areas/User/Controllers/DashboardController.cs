using Microsoft.AspNetCore.Mvc;

namespace FoodOrderUI.Web.Areas.User.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
