using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace OnlineShopping.DataAccess.Models
{
    public class Cart
    {        
        public int Id { get; set; }        
        public int? UserId { get; set; }      
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int CartStatusId { get; set; }
        public decimal Price { get; set; }

        public int? CartItemId { get; set; }

        public string? Color { get; set; }
        public int? Brand { get; set; }
        public string? ProductModel { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }

        public decimal? Weight { get; set; }
        public bool IsSelected { get; set ; }
        //public bool? AllSelected { get; set; }





    }
}
