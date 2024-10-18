using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Web.Controllers
{
    public class PurchaseOrderItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
