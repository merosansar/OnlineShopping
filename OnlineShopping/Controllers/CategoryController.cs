using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DataAccess.Models;

using OnlineShopping.Web.Services.CategoryService;
using OnlineShopping.DataAccess.Repository;

namespace OnlineShopping.Web.Controllers
{
    public class CategoryController(EshopContext context, ICategoryService categoryService) : Controller
    {
        private readonly EshopContext _context = context;
        private readonly ICategoryService _categoryService = categoryService;

        public IActionResult Index()
        {
            var list = new List<Category>();           
            var i = _context.TblCategories.ToList();
            if (i != null) {
                foreach (var item in i)
                {
                    var m = new Category
                    {
                        CategoryId = item.Id,
                        CategoryName = item.Name,
                        Description = item.Description
                    };
                list.Add(m);
            }
            }
            return View(list);
        }
        public IActionResult Create() 
        { 
            var i = new Category();
            ViewBag.Message = "";
            return View(i); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category m)
        {
            var i = new Category();           
            var result = await _categoryService.AddCategoryAsync("i", m.CategoryId, m.CategoryName??"", m.Description??"");
            ViewBag.Message = result.Message;
            return View(i);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id != 0)
            {
                var result = _categoryService.GetCategory("f", id, "", "");
                return View(result.ToList().FirstOrDefault());
            }
           return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(TblCategory m)
        {
          
            var result = _categoryService.UpdateCategory("u", m.Id, m.Name ?? "", m.Description ?? "");
            ViewBag.Message = result.ToList().FirstOrDefault()?.Message;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id != 0)
            {
                var result = _categoryService.GetCategory("f", id, "", "");
                return View(result.ToList().FirstOrDefault());
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                var result = _categoryService.GetCategory("f", id, "", "");
                return View(result.ToList().FirstOrDefault());
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteCat(int Id)
        {
            if (Id != 0)
            {
                var result = _categoryService.DeleteCategory("d", Id, "", "");
                if (result != null) { return RedirectToAction("Index"); }
               
            }
            return View();
        }


    }
}
