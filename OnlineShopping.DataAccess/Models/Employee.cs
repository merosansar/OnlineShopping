using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.DataAccess.Models
{
    public class Employee
    {

        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string? EmployeeName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }

        [StringLength(20)]
        [Phone]
        public string? PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        public int? ManagerId { get; set; }
        public Employee? Manager { get; set; }

        public ICollection<Employee>? Subordinates { get; set; }
    }
}
