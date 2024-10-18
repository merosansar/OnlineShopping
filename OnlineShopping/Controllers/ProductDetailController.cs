using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using OnlineShopping.Utility.LoadDropdown;
using OnlineShopping.Web.Services.IService;
using OnlineShopping.Web.Services.Service;
using System.Collections.Generic;

namespace OnlineShopping.Web.Controllers
{
    public class ProductDetailController(EshopContext context, IProductDetailsService ProductDetailsService, Dropdown dropdown) : Controller
    {
        private readonly EshopContext _context = context;
        private readonly Dropdown Dropdown = dropdown;

        private readonly IProductDetailsService _IProductDetailsService = ProductDetailsService;

        // GET: ProductDetailController
        public ActionResult Index()
        {
            var n = new ProductDetails();
            var list = _IProductDetailsService.GetProductDetails("s", n.Id, n.ProductId ?? 0, n.Description ?? "", n.Specifications ?? "",n.Brand??0, n.ProductModel ?? "", n.Warranty ?? "", n.Material ?? "", n.Color ?? "", n.Dimensions ?? "", n.Weight ?? 0, n.PromotionStartDate, n.PromotionEndDate, n.SpecialPrice).ToList();
            n.ProductDetailsList = list;
            return View(n);
        }

        // GET: ProductDetailController/Details/5
        public ActionResult Details(int id)
        {
            var n = new ProductDetails();
            var list = _IProductDetailsService.GetProductDetails("f", id, n.ProductId ?? 0, n.Description ?? "", n.Specifications ?? "", n.Brand ?? 0, n.ProductModel ?? "", n.Warranty ?? "", n.Material ?? "", n.Color ?? "", n.Dimensions ?? "", n.Weight ?? 0, n.PromotionStartDate, n.PromotionEndDate, n.SpecialPrice).ToList().FirstOrDefault();
            return View(list);
        }

        // GET: ProductDetailController/Create
        public ActionResult Create(Product model)
        {
           
           
            var n = new ProductDetails();
            var list = _IProductDetailsService.GetProductDetails("s", n.Id, model.Id, n.Description ?? "", n.Specifications ?? "", n.Brand ??0 , n.ProductModel ?? "", n.Warranty ?? "", n.Material ?? "", n.Color ?? "", n.Dimensions ?? "", n.Weight ?? 0,n.PromotionStartDate, n.PromotionEndDate, n.SpecialPrice).ToList();
            var i = Dropdown.GetDropDownList("BrandData", "");
            var c = Dropdown.GetDropDownList("ColorData", "");
            var m = new ProductDetails
            {
                ProductDetailsList = list,
                BrandList = i,
                ColorList = c,
                ProductId = model.Id
                
            };
            return View(m);
        
       
    }

        // POST: ProductDetailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductDetails m, string PromotionDateRange)
        {
            try
            {
                if (m != null)
                {
                    if (PromotionDateRange != null)
                    {
                        var formattedDates = FormatDateRange(PromotionDateRange);
                        m.PromotionStartDate = Convert.ToDateTime(formattedDates.Item1);
                        m.PromotionEndDate = Convert.ToDateTime(formattedDates.Item2);

                    }
                    //else
                    //{
                    //    toDate = Convert.ToString(DateTime.Now);
                    //    fromDate = Convert.ToDateTime(toDate).AddDays(-7).Date.ToString("yyyy-MM-dd");
                    //}
                    var i = _IProductDetailsService.ChangeProductDetails("i", m.Id, m.ProductId ?? 0, m.Description ?? "", m.Specifications ?? "",m.Brand ?? 0, m.ProductModel ?? "", m.Warranty ?? "", m.Material ?? "", m.Color ?? "", m.Dimensions ?? "", m.Weight ?? 0, m.PromotionStartDate,m.PromotionEndDate, m.SpecialPrice).ToList().FirstOrDefault();
                    if (i != null)
                    {
                        var list = _IProductDetailsService.GetProductDetails("s", m.Id, m.ProductId ?? 0, m.Description ?? "", m.Specifications ?? "", m.Brand ?? 0, m.ProductModel ?? "", m.Warranty ?? "", m.Material ?? "", m.Color ?? "", m.Dimensions ?? "", m.Weight ?? 0, m.PromotionStartDate, m.PromotionEndDate, m.SpecialPrice).ToList();
                        ViewBag.Message = i.Message;
                        m.ProductDetailsList = list;
                    }
                    return RedirectToAction("Index","Home");
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: ProductDetailController/Edit/5
        public ActionResult Edit(int id)
        {
            var n = new ProductDetails();
            var list = _IProductDetailsService.GetProductDetails("f", id, n.ProductId ?? 0, n.Description ?? "", n.Specifications ?? "", n.Brand ?? 0, n.ProductModel ?? "", n.Warranty ?? "", n.Material ?? "", n.Color ?? "", n.Dimensions ?? "", n.Weight ?? 0, n.PromotionStartDate, n.PromotionEndDate,n.SpecialPrice).ToList().FirstOrDefault();
            var model = _IProductDetailsService.GetProductDetails("s", n.Id, n.ProductId ?? 0, n.Description ?? "", n.Specifications ?? "", n.Brand ??0, n.ProductModel ?? "", n.Warranty ?? "", n.Material ?? "", n.Color ?? "", n.Dimensions ?? "", n.Weight ?? 0, n.PromotionStartDate, n.PromotionEndDate, n.SpecialPrice).ToList();
            //if (model != null)
            //{
            //    n.ProductDetailsList = model;
            //}
            if (list != null)
            {
                var i = new ProductDetails
                {
                    Id = list.Id,
                    ProductId = list.ProductId,
                    Description = list.Description,
                    Specifications = list.Specifications,
                    Brand = list.Brand,
                    ProductModel = list.ProductModel,
                    Warranty = list.Warranty,
                    Material = list.Material,
                    Color = list.Color,
                    Dimensions = list.Dimensions,
                    Weight = list.Weight,
                    ProductDetailsList = model

                };
                return View(i);
            }
           
            return RedirectToAction("Index");
        }

        // POST: ProductDetailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductDetails m)
        {
            try
            {
                if (m != null)
                {
                    var i = _IProductDetailsService.ChangeProductDetails("u", m.Id, m.ProductId ?? 0, m.Description ?? "", m.Specifications ?? "", m.Brand ?? 0, m.ProductModel ?? "", m.Warranty ?? "", m.Material ?? "", m.Color ?? "", m.Dimensions ?? "", m.Weight ?? 0 ,m.PromotionStartDate, m.PromotionEndDate,m.SpecialPrice).ToList().FirstOrDefault();
                    if (i!= null)
                    {
                        ViewBag.Message = i.Message;
                    }

                }
                return View(m);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductDetailController/Delete/5
        public ActionResult Delete(int id)
        {
            var n = new ProductDetails();
            var model = _IProductDetailsService.GetProductDetails("f", id, n.ProductId ?? 0, n.Description ?? "", n.Specifications ?? "", n.Brand ?? 0, n.ProductModel ?? "", n.Warranty ?? "", n.Material ?? "", n.Color ?? "", n.Dimensions ?? "", n.Weight ?? 0, n.PromotionStartDate, n.PromotionEndDate, n.SpecialPrice).ToList().FirstOrDefault();
            return View(model);
        }

        // POST: ProductDetailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDetails(int Id)
        {
            var n = new ProductDetails();
            try
            {
                var model = _IProductDetailsService.ChangeProductDetails("d", Id, n.ProductId ?? 0, n.Description ?? "", n.Specifications ?? "", n.Brand ?? 0, n.ProductModel ?? "", n.Warranty ?? "", n.Material ?? "", n.Color ?? "", n.Dimensions ?? "", n.Weight ?? 0, n.PromotionStartDate, n.PromotionEndDate, n.SpecialPrice).ToList().FirstOrDefault();
               return RedirectToAction("Index");    
            }
            catch
            {
                return View();
            }
        }

        public static Tuple<string, string> FormatDateRange(string dateRange)
        {
            // Split the date range into two dates 
            var dates = dateRange.Split('-');

            // Function to format a date in MM/DD/YYYY format to YYYY-MM-DD
            string FormatDate(string date)
            {
                var dateParts = date.Split('/');
                var month = dateParts[0].PadLeft(2, '0');
                var day = dateParts[1].PadLeft(2, '0');
                var year = dateParts[2];
                return $"{year}-{month}-{day}";
            }

            // Format both dates
            var formattedStartDate = FormatDate(dates[0]);
            var formattedEndDate = FormatDate(dates[1]);

            return Tuple.Create(formattedStartDate, formattedEndDate);
        }
    }
}
