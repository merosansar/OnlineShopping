using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        // Navigation property
        public ICollection<Employee> Employees { get; set; }
    }
}
