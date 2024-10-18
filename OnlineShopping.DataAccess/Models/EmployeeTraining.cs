using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.DataAccess.Models
{
    public class EmployeeTraining
    {
        [Key]
        public int TrainingId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        [Required]
        [StringLength(100)]
        public string? TrainingName { get; set; }

        [DataType(DataType.Date)]
        public DateTime TrainingDate { get; set; }

        [StringLength(20)]
        public string? CompletionStatus { get; set; }
    }
}
