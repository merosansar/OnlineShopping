using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopping.Utility.LoadDropdown;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using OnlineShopping.Web.Services.IService;
using System.Diagnostics;

namespace OnlineShopping.Web.Controllers
{
    public class ProductController(EshopContext context, Dropdown dropdown, IProductService iProductService) : Controller
    {

        public readonly EshopContext _context = context;
        private readonly Dropdown Dropdown = dropdown;
        private readonly IProductService _IProductService = iProductService;

        public IActionResult Index()
        {
            var m = new Product();
            var result = _IProductService.GetProduct("s", m.Id, m.Name??"", m.Description ?? "", m.CategoryId ?? 0,Convert.ToDecimal( m.Price), m.Quantity, m.ImageUrl ?? "", m.SubCatId ?? 0, m.ItemId ?? 0, m.Rating ?? 0).ToList();
            return View(result);
        }

        public IActionResult Create()
        {
           
                        
            var i = Dropdown.GetDropDownList("CatData", "");              
            var j  = Dropdown.GetDropDownList("SubCatData", "");                
            var k = Dropdown.GetDropDownList("ItemData", "");
            

            var m = new Product
            {
               
               
                CategoryList = i,
                SubCcategoryList = j,
                ItemList = k
            };



            return View(m);
        }

        [HttpPost]
    
        public IActionResult Create(Product m )
        {
            var result = _IProductService.ChangeProduct("i", m.Id, m.Name ?? "",m.Description??"", m.CategoryId ?? 0, m.Price, m.Quantity, m.ImageUrl??"",m.SubCatId ?? 0, m.ItemId ?? 0,m.Rating??0).ToList().FirstOrDefault();
            if (result != null)
            {
                var list = _IProductService.GetProduct("f", m.Id, m.Name ?? "", m.Description ?? "", m.CategoryId ?? 0, Convert.ToDecimal(m.Price), m.Quantity, m.ImageUrl ?? "", m.SubCatId ?? 0, m.ItemId ?? 0, m.Rating ?? 0).ToList().FirstOrDefault();
                if (list != null)
                {
                    m.Id = list.Id;
                    return RedirectToAction("Create", "ProductDetail", m);
                }
            }
            return View();


        }

        public IActionResult Edit(int id)
        {
            var result = _IProductService.GetProduct("f", id, "", "", 0, 0, 0, "", 0, 0,0)
                                 .ToList()
                                 .FirstOrDefault();

            if (result == null)
            {
                return NotFound(); // Handle the case where the product is not found
            }

            var categoryList = Dropdown.GetDropDownList("CatData", "");
            var subCategoryList = Dropdown.GetDropDownList("SubCatData", "");
            var itemList = Dropdown.GetDropDownList("ItemData", "");

            var model = new Product
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                CategoryId = result.CategoryId,
                Price = result.Price,
                Quantity = result.Quantity,
                ImageUrl = result.ImageUrl,
                CreatedBy = result.CreatedBy,
                CreatedDate = result.CreatedDate,
                UpdatedBy = result.UpdatedBy,
                UpdatedDate = result.UpdatedDate,
                SubCatId = result.SubCatId,
                ItemId = result.ItemId,
                CategoryList = categoryList,
                SubCcategoryList = subCategoryList,
                ItemList = itemList
            };



            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Product m)
        {
           
            var result = _IProductService.ChangeProduct("u", m.Id, m.Name ?? "", m.Description ?? "", m.CategoryId ?? 0, m.Price, m.Quantity, m.ImageUrl ?? "", m.SubCatId ?? 0, m.ItemId ?? 0, m.Rating ?? 0).ToList().FirstOrDefault();
            if (result != null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index");

        }
        public IActionResult Details(int id)
        {
            var result = _IProductService.GetProduct("f", id, "", "", 0, 0, 0, "", 0, 0,0)
                                 .ToList()
                                 .FirstOrDefault();

            if (result == null)
            {
                return NotFound(); // Handle the case where the product is not found
            }

            //var categoryList = Dropdown.GetDropDownList("CatData", "");
            //var subCategoryList = Dropdown.GetDropDownList("SubCatData", "");
            //var itemList = Dropdown.GetDropDownList("ItemData", "");

            var model = new Product
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                CategoryId = result.CategoryId,
                Price = result.Price,
                Quantity = result.Quantity,
                ImageUrl = result.ImageUrl,
                CreatedBy = result.CreatedBy,
                CreatedDate = result.CreatedDate,
                UpdatedBy = result.UpdatedBy,
                UpdatedDate = result.UpdatedDate,
                SubCatId = result.SubCatId,
                ItemId = result.ItemId,
                //CategoryList = categoryList,
                //SubCcategoryList = subCategoryList,
                //ItemList = itemList
            };



            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var m = new Product();
            var result = _IProductService.GetProduct("f", id, m.Name ?? "", m.Description ?? "", m.CategoryId ?? 0, m.Price, m.Quantity, m.ImageUrl ?? "", m.SubCatId ?? 0, m.ItemId ?? 0, m.Rating ?? 0).ToList();

           
            m = result.FirstOrDefault();
            return View(m);
        }
        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var m = new Product();
            var result = _IProductService.ChangeProduct("d", id, m.Name ?? "", m.Description ?? "", m.CategoryId ?? 0, m.Price, m.Quantity, m.ImageUrl ?? "", m.SubCatId ?? 0, m.ItemId ?? 0, m.Rating ?? 0).ToList();
            if(result.Count > 0) { return RedirectToAction("Index"); }

            else
                return RedirectToAction("Delete",id);

        }
        public List<SelectListItem> GetList(string Param,string Filter) 
        {          
             var i = Dropdown.GetDropDownList(Param, Filter);
            return i;
        }

        public IActionResult ProductList()
        {
            var m = new Product();
            var result = _IProductService.GetProduct("s", m.Id, m.Name ?? "", m.Description ?? "", m.CategoryId ?? 0, Convert.ToDecimal(m.Price), m.Quantity, m.ImageUrl ?? "", m.SubCatId ?? 0, m.ItemId ?? 0, m.Rating ?? 0).ToList();
            return View(result);
        }

        public IActionResult ProductDetails(int Id)
        {
            var m = new Product();
            var result = _IProductService.GetProduct("f", Id, m.Name ?? "", m.Description ?? "", m.CategoryId ?? 0, Convert.ToDecimal(m.Price), m.Quantity, m.ImageUrl ?? "", m.SubCatId ?? 0, m.ItemId ?? 0, m.Rating ?? 0).ToList().FirstOrDefault();
            return View(result);
        }


    }
}
