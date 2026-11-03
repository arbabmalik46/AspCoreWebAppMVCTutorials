using System.ComponentModel.DataAnnotations;

namespace CRUDusingADO.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public string Designation { get; set; }
    }
}
