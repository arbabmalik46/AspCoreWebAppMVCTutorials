using CodeFirstASPCore6.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstASPCore6.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        [Column("StudentID", TypeName = "int")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        [Column("FullName", TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [Column("Description", TypeName = "nvarchar(500)")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Column("Email", TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
        [Column("PhoneNumber", TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        //[Range(typeof(DateTime), "1900-01-01", "2010-12-31", ErrorMessage = "Date of birth must be between 1900 and 2010")]
        [Column("DateOfBirth", TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Enrollment date is required")]
        [DataType(DataType.Date)]
        [Column("EnrollmentDate", TypeName = "date" )]
        public DateTime EnrollmentDate { get; set; }

        [Range(0, 4.0, ErrorMessage = "GPA must be between 0 and 4.0")]
        [Column("GPA", TypeName = "decimal(3,2)")]
        public decimal? GPA { get; set; }
        public TierList Tier { get; set; }

    }
}
