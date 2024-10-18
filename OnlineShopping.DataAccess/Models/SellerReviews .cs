using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.DataAccess.Models
{
    public class SellerReviews
    {

        [Key]
        public int SellerReviewId { get; set; }

        [ForeignKey("Seller")]
        public int SellerId { get; set; }
        public Seller? Seller { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User?     User { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string? Comment { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ReviewDate { get; set; } = DateTime.Now;
    }
}
