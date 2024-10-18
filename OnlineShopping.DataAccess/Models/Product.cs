using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopping.DataAccess.Repository;






namespace OnlineShopping.DataAccess.Models
{
    public class Product
    {

        public int Id { get; set; }                // Primary Key
        public string? Name { get; set; }           // Product name
        public string? Description { get; set; }    // Product description
        public int? CategoryId { get; set; }        // Foreign Key to Category (if applicable)
        public decimal Price { get; set; }         // Product price
        public int Quantity { get; set; }          // Quantity in stock
        public string? ImageUrl { get; set; }       // URL for the product image
        public string? CreatedBy { get; set; }      // User who created the product
        public DateTime CreatedDate { get; set; }  // Date and time when the product was created
        public string? UpdatedBy { get; set; }      // User who last updated the product
        public DateTime? UpdatedDate { get; set; } // Date and time when the product was last updated (nullable)
        public int? SubCatId { get; set; }         // Foreign Key to SubCategory (if applicable)
        public int? ItemId { get; set; }
        public int? Rating { get; set; }

      
        public List<SelectListItem>? CategoryList { get; set; }
        public List<SelectListItem>? SubCcategoryList { get; set; }
        public List<SelectListItem>? ItemList { get; set; }
        //public TblSubCategory SubCategory { get; set; }
        //public ItemModel Item { get; set; }


    }
}
