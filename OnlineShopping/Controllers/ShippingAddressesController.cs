﻿using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Web.Controllers
{
    public class ShippingAddressesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create() { return View(); }
    }
}
