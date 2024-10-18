using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Models
{
    public class Shipping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShippingId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [StringLength(255)]
        public string ShippingAddress { get; set; }

        public DateTime? ShippingDate { get; set; }

        [StringLength(20)]
        public string ShippingStatus { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
