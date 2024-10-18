using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace OnlineShopping.Models
{
    public class SubCategory
    {
        
        public int? Id { get; set; }      
        public string? Name { get; set; }
        public int? CatId { get; set; }
        public List<SelectListItem>? Dropdowndata { get; set; }

    }
}
