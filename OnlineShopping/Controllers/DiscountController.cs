﻿using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Web.Controllers
{
    public class DiscountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
