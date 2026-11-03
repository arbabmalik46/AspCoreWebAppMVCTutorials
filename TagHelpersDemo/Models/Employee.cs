using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace TagHelpersDemo.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        //[Required]
        //public int Age { get; set; }
        //[Required]
        //public decimal Salary { get; set; }
        //public enum Gender { Male, Female };
        //[Required]
        //public bool Married { get; set; }
        //public Gender EmployeeGender { get; set; }
        //[Required]
        //public string Description { get; set; }

    }
}
