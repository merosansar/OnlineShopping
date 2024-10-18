using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Web.Controllers
{
    public class WishlistItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
