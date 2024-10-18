using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShopping.DataAccess.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? SubCatId { get; set; }
        public string? SubCatName { get; set; }

      
        public List<SelectListItem>? SelectedList { get; set; }

    }
}
