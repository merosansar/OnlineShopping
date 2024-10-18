using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShopping.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubCatId { get; set; }
        public List<SelectListItem> selectedList { get; set; }

    }
}
