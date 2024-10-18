using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.DataAccess.Models
{
    public class Coupon
    {


        public int CouponId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Coupon Code")]
        public string? CouponCode { get; set; }

        [Required]
        [Display(Name = "Discount Percentage")]
        [Range(0.01, 100.00)]
        public decimal DiscountPercentage { get; set; }

        [Display(Name = "Minimum Purchase Amount")]
        [Range(0.01, 1000000.00)]
        public decimal? MinimumPurchaseAmount { get; set; }

        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;
    }
}
