using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Web.Controllers
{
    public class AppliedCouponsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
