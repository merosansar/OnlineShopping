using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopping.Utility.LoadDropdown;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.Web.Services.IService;
using OnlineShopping.Web.Services.Service;

namespace OnlineShopping.Web.Controllers
{
    public class ItemController(
        ILoadDropdownService subcategory,
        IItemService itemService,
        Dropdown dropdown
        ) : Controller
    {
        public ILoadDropdownService Subcategory { get; init; } = subcategory;
        public IItemService ItemService { get; init; } = itemService;


        private readonly Dropdown Dropdown = dropdown;

        public IActionResult Index() 
        {
            var list = ItemService.GetItemList("s", null, null, null ?? "").ToList();

            return View(list);
        }
        public IActionResult Create()
        {
            var i = Dropdown.GetDropDownList("SubCatData", "").ToList();
            //var subcatList = new List<SelectListItem>();
            var m = new ItemModel {
                SelectedList = i
        };
            return View(m);
        }
        [HttpPost]
        public ActionResult Create(ItemModel n) 
        {
          
            var result = ItemService.AddItemAsync("i", n.Id, n.SubCatId, n.Name?? "").FirstOrDefault();
        
            if (result != null)
            {
                ViewBag.Message = result.Message;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            //var m = new ItemModel();
            var i = Dropdown.GetDropDownList("SubCatData", "").ToList();
            var result = ItemService.GetItemList("f",id,null, null ?? "").FirstOrDefault();
            if (result != null) { result.SelectedList = i; }
           
           
            return View(result);



        }
        [HttpPost]
        public ActionResult Edit(ItemModel n)
        {
           
            var result = ItemService.UpdateItem("u", n.Id, n.SubCatId, n.Name ?? "").FirstOrDefault();
            if(result==null) { return View(null); }
            return RedirectToAction("Index");
         
        }

        public IActionResult Details(int id)
        {
          
            var result = ItemService.GetItemList("f", id, null, null ?? "").FirstOrDefault();
           
            return View(result);



        }

        public IActionResult Delete(int id)
        {

            var result = ItemService.GetItemList("f", id, null, null ?? "").FirstOrDefault();

            return View(result);



        }
        [HttpPost]
        public IActionResult DeleteItem(int Id)
        {

            var result = ItemService.DeleteItem("d", Id, 0, null ?? "").FirstOrDefault();
            if (result == null) { return View(null); }
            return RedirectToAction("Index");



        }
    }
}
