using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Utility.LoadDropdown;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.Web.Services.IService;
using OnlineShopping.Web.Services.Service;
using OnlineShopping.Web.ViewModel;
using System.Diagnostics;

namespace OnlineShopping.Web.Controllers
{
    public class HomeController(ILogger<HomeController> logger, ILoadDropdownService category, ISubCategoryService subCatContext, IProductService iProductService, IItemService itemContext, ICartService CartService
        ) : Controller
    {
        public ILogger<HomeController> Logger { get; init; } = logger;
        //The public ILogger<HomeController> Logger { get; init; } property allows you
        //to create immutable objects with a flexible initialization process.
        //You can set the property value during object creation, but once the object is created, the property cannot be modified,
        //which helps maintain object consistency and safety.
        public ILoadDropdownService Category { get; init; } = category;
        public ISubCategoryService SubCatContext { get; init; } = subCatContext;
        public IItemService ItemContext { get; init; } = itemContext;
        private readonly IProductService _IProductService = iProductService;
        private readonly ICartService _CartService = CartService;
        public IActionResult Index()
        {
            var n = new HomeViewModel();
            var m = new Product();
            var cart = new Cart();
            int? UserId = HttpContext.Session.GetInt32("UserId");
            var categories = Category.GetDropdownData("CatData", "").ToList();
            var subcat = SubCatContext.GetSubCatList("s", "", 0, 0).ToList();
            var ItemList = ItemContext.GetItemList("s", 0, 0, "").ToList();
            var result = _IProductService.GetProduct("s", m.Id, m.Name ?? "", m.Description ?? "", m.CategoryId ?? 0, Convert.ToDecimal(m.Price), m.Quantity, m.ImageUrl ?? "", m.SubCatId ?? 0, m.ItemId ?? 0, m.Rating ?? 0).ToList();
            if (result.Count > 0) { n.ProductList = result; }
           
            var count = _CartService.GetCartTotalCount("c", m.Id, UserId ?? 0, cart.CartItemId ?? 0, cart.ProductId, cart.Quantity, cart.Price,cart.IsSelected).ToList().FirstOrDefault();
            //if (count == null) { TempData["CartTotalCount"] = "0"; }
            //else { TempData["CartTotalCount"] = count.TotalCartItem; }

            TempData["CartTotalCount"] = count == null ? "0" : count.TotalCartItem.ToString();

            n.CatList = categories;
            n.SubCatList = subcat;
            n.Itemlist = ItemList;
            if (!UserId.HasValue  && (count == null ))
            {
                // Handle case where ID is not in session
                ViewBag.Message = "No UserId in Session";
                return View(n);
               
            }
            var addCartStatus = "";
            if (TempData["AddToCart"]!=null) { addCartStatus = TempData["AddToCart"].ToString(); }
           

            if (UserId.HasValue && (addCartStatus=="Yes"))
            {
                var Id = TempData["ProductId"].ToString();
                // Handle case where ID is not in session
              
                return RedirectToAction("ProductDetails", "Product", new { Id = Convert.ToInt32(Id) });

            }


            return RedirectToAction("Login", "User");

        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult MainCategory()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult ProductList()
        {
            var m = new Product();
            var result = _IProductService.GetProduct("s", m.Id, m.Name ?? "", m.Description ?? "", m.CategoryId ?? 0, Convert.ToDecimal(m.Price), m.Quantity, m.ImageUrl ?? "", m.SubCatId ?? 0, m.ItemId ?? 0, m.Rating ?? 0).ToList();
            return View(result);
        }
    }
}
