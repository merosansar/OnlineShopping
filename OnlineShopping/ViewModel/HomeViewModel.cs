using OnlineShopping.DataAccess.Models;

namespace OnlineShopping.Web.ViewModel
{
    public class HomeViewModel
    {
        public List<LoadDropdownModel>? CatList { get; set; }
        public List<SubCategory>? SubCatList { get; set; }

        public List<ItemModel>? Itemlist { get; set; }
        public List<Product>? ProductList { get; set; }

    }
}
