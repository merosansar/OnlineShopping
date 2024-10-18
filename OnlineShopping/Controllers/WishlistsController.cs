using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Web.Controllers
{
    public class WishlistsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
