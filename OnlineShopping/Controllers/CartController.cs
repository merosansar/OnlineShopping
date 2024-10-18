using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using OnlineShopping.Web.Services.CategoryService;
using OnlineShopping.Web.Services.IService;
using OnlineShopping.Web.Services.Service;
using OnlineShopping.Web.ViewModel;

namespace OnlineShopping.Web.Controllers
{
    public class CartController(EshopContext context, ICartService CartService) : Controller
    {
        public readonly EshopContext _context = context;
        private readonly ICartService _CartService = CartService;

        public IActionResult Index(Cart m)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId"); // Retrieve the integer ID from the session
            if (!UserId.HasValue)
            {
                // Handle case where ID is not in session
                ViewBag.Message = "No UserId in Session";
                return RedirectToAction("Login", "User");
            }
            var result = _CartService.GetCart("s", m.Id, UserId??0,  m.CartItemId??0, m.ProductId, m.Quantity, m.Price,m.IsSelected);
            var count = _CartService.GetCartTotalCount("c", m.Id, UserId??0, m.CartItemId ?? 0, m.ProductId, m.Quantity, m.Price,m.IsSelected).ToList().FirstOrDefault();
            //if (count == null) { TempData["CartTotalCount"] = "0"; }
            //else { TempData["CartTotalCount"] = count.TotalCartItem; }

            TempData["CartTotalCount"] = count == null ? "0" : count.TotalCartItem.ToString();

            return View(result);
        }

        [HttpPost]
        public IActionResult Index(List<Cart> List)
        {
           var OrderList = new List<Cart>(); 
            foreach (var item in List) {

                if(item.IsSelected==true)
                {
                    var result = _CartService.ChangeCart("u", item.Id,  0, item.CartItemId ?? 0, item.ProductId, item.Quantity, item.Price, item.IsSelected).ToList().FirstOrDefault();
                    if (result != null)
                    {
                        OrderList.Add(item);
                    }
                }

            }
            return RedirectToAction("Create", "Order", OrderList);



            //if (ModelState.IsValid)
            //{
            //    // Check if Quantities is not null or empty
            //    if (!string.IsNullOrEmpty(model.Quantities))
            //    {
            //        try
            //        {
            //            // Deserialize the JSON string to a dictionary
            //            var quantities = JsonConvert.DeserializeObject<Dictionary<int, int>>(model.Quantities);

            //            // Process selected items and quantities
            //            if (quantities != null)
            //            {
            //                foreach (var kvp in quantities)
            //                {
            //                    int itemId = kvp.Key;
            //                    int quantity = kvp.Value;

            //                    // Retrieve and process each item based on the ID and quantity
            //                }
            //            }
            //        }
            //        catch (JsonException)
            //        {
            //            // Handle JSON parsing error
            //            ModelState.AddModelError("", "Error parsing quantities data.");
            //            return View(model);
            //        }
            //    }
            //    else
            //    {
            //        // Handle the case where Quantities is null or empty
            //        ModelState.AddModelError("", "Quantities data is missing.");
            //        return View(model);
            //    }

            //    // Redirect or return a view with success message
            //    return RedirectToAction("Success");
            //}

            //If the model state is invalid, return to the form with validation errors
            return View();
        }


        public IActionResult Create(Product  m)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId"); // Retrieve the integer ID from the session
            if (!UserId.HasValue)
            {
                // Handle case where ID is not in session
                ViewBag.Message = "No UserId in Session";
                return RedirectToAction("Login", "User");
            }
           
            var i = new Cart();
            var result = _CartService.ChangeCart("i", i.Id,UserId??0,i.CartItemId??0,m.Id, m.Quantity, m.Price,i.IsSelected).ToList().FirstOrDefault();
            if (result == null)
            {
                return View(i);
            }
            else
            {
                i.ProductId = m.Id;
                return RedirectToAction("Index",i);
            }


        }

        [HttpPost]  
        public IActionResult Create(Cart m) 
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (!UserId.HasValue)
            {
                // Handle case where ID is not in session
                ViewBag.Message = "No UserId in Session";
                return RedirectToAction("Login", "User");
            }
            var i = new Cart();
            var result = _CartService.ChangeCart("i", m.Id, UserId??0, m.CartItemId??0, m.ProductId, m.Quantity, m.Price,m.IsSelected).ToList().FirstOrDefault();
            if (result == null)
            {
                return View(i);
            }
            else 
            { 
                return RedirectToAction("Index");
            }
            
           
        }

    }
}
