using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.DataAccess.Models
{
    public class SellerOrder
    {

        [Key]
        public int SellerOrderId { get; set; }

        [ForeignKey("Seller")]
        public int SellerId { get; set; }
        public Seller?  Seller { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalAmount { get; set; }

        [StringLength(20)]
        public string? OrderStatus { get; set; }
    }
}
