using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using OnlineShopping.Utility.LoadDropdown;
using OnlineShopping.Web.Services.IService;
using OnlineShopping.Web.Services.Service;

namespace OnlineShopping.Web.Controllers
{
    public class SellerController(EshopContext context, IDashboardService dashboardService) : Controller
    {
        public readonly EshopContext _context = context;
        private readonly IDashboardService _dashboardService = dashboardService;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {

           
            int? UserId = HttpContext.Session.GetInt32("UserId"); // Retrieve the integer ID from the session
            var  FullName = HttpContext.Session.GetString("FullName"); // Retrieve the string FullName from the session
            var Username = HttpContext.Session.GetString("Username"); // Retrieve the string Username from the session

            if (!UserId.HasValue)
            {
                // Handle case where ID is not in session
                ViewBag.Message = "No UserId in Session";
                return RedirectToAction("Login", "User");
            }
            var i = _dashboardService.GetAll();
            TempData["FullName"] = FullName;
            TempData["Username"] = Username;



            return View(i);
        }
        public IActionResult Create() { return View(); }
    }
}
