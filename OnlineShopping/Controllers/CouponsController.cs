﻿using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Web.Controllers
{
    public class CouponsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create () { return View(); }
    }
}
