using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Web.Controllers
{
    public class InvoiceItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
