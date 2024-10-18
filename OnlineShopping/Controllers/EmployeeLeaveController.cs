using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Web.Controllers
{
    public class EmployeeLeaveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create() { return View(); }
    }
}
