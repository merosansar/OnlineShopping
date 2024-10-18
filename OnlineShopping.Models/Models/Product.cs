using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopping.Web.Repository;

namespace OnlineShopping.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string? ProductName { get; set; }

        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Display(Name = "Quantity")]
        public int QuantityAvailable { get; set; }

        [StringLength(255)]
        public string? ImageUrl { get; set; }

        public List<SelectListItem>? categiryList { get; set; }
        public List<SelectListItem>? subCcategoryList { get; set; }
        public List<SelectListItem>? itemList { get; set; }
        public TblSubCategory SubCategory { get; set; }       
        public ItemModel Item { get; set; }


    }
}
