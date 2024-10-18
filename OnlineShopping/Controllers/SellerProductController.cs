using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Web.Controllers
{
    public class SellerProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
