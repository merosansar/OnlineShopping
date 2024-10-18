using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.DataAccess.Models
{
    public class SellerProduct
    {
        [Key]
        public int SellerProductId { get; set; }

        [ForeignKey("Seller")]
        public int SellerId { get; set; }
        public Seller? Seller { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
