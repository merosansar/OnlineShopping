using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Web.Controllers
{
    public class SellerOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
