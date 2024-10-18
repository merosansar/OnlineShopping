using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Web.Controllers
{
    public class NotificationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create() { return View(); }
    }
}
