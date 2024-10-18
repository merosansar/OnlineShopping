using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Web.Controllers
{
    public class StockMovementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
