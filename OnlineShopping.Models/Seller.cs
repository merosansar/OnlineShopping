using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Models
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }

        [Required]
        [StringLength(100)]
        public string SellerName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(20)]
        [Phone]
        public string PhoneNumber { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
