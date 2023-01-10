using Microsoft.AspNetCore.Mvc;

namespace FoodOrderUI.Web.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
