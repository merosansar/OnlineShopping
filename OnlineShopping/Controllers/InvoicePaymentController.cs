using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Web.Controllers
{
    public class InvoicePaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
