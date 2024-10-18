using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Models
{
    public class EmployeePerformance
    {
        [Key]
        public int PerformanceId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [DataType(DataType.Date)]
        public DateTime EvaluationDate { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string Comments { get; set; }
    }
}
