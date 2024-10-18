using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.DataAccess.Models
{
    public class EmployeeBenefit
    {
        [Key]
        public int BenefitId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        //public Employee Employee { get; set; }

        [Required]
        [StringLength(100)]
        public string? BenefitName { get; set; }

        public string? BenefitDescription { get; set; }
    }
}
