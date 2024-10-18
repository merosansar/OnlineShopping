using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.DataAccess.Models
{
    public class CouponUsage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsageId { get; set; }

        [ForeignKey("Coupon")]
        public int CouponId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UsageDate { get; set; } = DateTime.Now;

        //public virtual Coupon Coupon { get; set; }
        //public virtual User User { get; set; }
        //public virtual Order Order { get; set; }
    }
}
