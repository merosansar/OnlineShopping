using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopping.Utility.LoadDropdown;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using OnlineShopping.Web.Services.CategoryService;
using OnlineShopping.Web.Services.IService;
using OnlineShopping.Web.Services.Service;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopping.Web.Controllers
{
    public class SubCategoryController(ILoadDropdownService categoryService, ISubCategoryService subCategory, Dropdown dropdown) : Controller
    {

        public readonly ILoadDropdownService _category = categoryService;
        private readonly ISubCategoryService _subCategory = subCategory;
        private readonly Dropdown Dropdown = dropdown;

        public IActionResult Index()
        {
           
            var i = _subCategory.GetSubCatList("s", null??"", null,null).ToList();           
            return View(i);
          
        }
        [HttpGet]
        public IActionResult Create()
        {            
            var i = Dropdown.GetDropDownList("CatData", "");           
            var m = new SubCategory()
            { 
                Dropdowndata = i
            };                  
            return View(m);
        }
        [HttpPost]
        public IActionResult Create(SubCategory m)
        {
           
            var result = _subCategory.AddSubCategoryAsync("i", 0, m.CatId, m.Name??"").FirstOrDefault();
            if (result == null) { return View(); }
           
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
           
            var i = Dropdown.GetDropDownList("CatData", "");           
          
          
            var subcat = _subCategory.GetSubCatList("f", null ?? "", id, null).ToList().FirstOrDefault();

            if (subcat != null) {
               var  m = new SubCategory()
                {
                    Name = subcat.Name,
                    Id = subcat.Id,
                    CatId = subcat.CatId,
                    CatName = subcat.CatName,
                   Dropdowndata = i
            };
               
                return View(m);

            }
            return View();

        }
        [HttpPost]
        public IActionResult Edit(SubCategory m)
        {
            if (m != null) 
            { 
            var result = _subCategory.UpdateSubCategory("u", m.Id, m.CatId, m.Name ?? "").FirstOrDefault();          
           if(result != null) { return RedirectToAction("Index"); }
            }
            else {  return View(); }
                return View();
           
        }


        [HttpGet]
        public IActionResult Details(int id)
        {

            //var i = Dropdown.GetDropDownList("CatData", "");
            //var m = new SubCategory();
            //m.Dropdowndata = i;
            var subcat = _subCategory.GetSubCatList("f", null ?? "", id, null).ToList().FirstOrDefault();
            //m.Name = subcat.Name;
            //m.Id = subcat.Id;
            //m.CatId = subcat.CatId;
            //m.CatName = subcat.CatName;
            return View(subcat);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

           
            var subcat = _subCategory.GetSubCatList("f", null ?? "", id, null).ToList().FirstOrDefault();           
            return View(subcat);
        }

        [HttpPost]
        public IActionResult DeleteSubCat(int Id)
        {
            var subcat = _subCategory.DeleteSubCategory("d",Id,null,null??"").ToList();
            if (subcat != null) { return RedirectToAction("Index"); }
            else
            { return View(); }
            
        }

    }

}
