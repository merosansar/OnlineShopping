using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Models
{
    public class Role
    {

        [Key]
        public int RoleId { get; set; }

        [Required]
        [StringLength(100)]
        public string RoleName { get; set; }

        public string Description { get; set; }

       
    }
}
