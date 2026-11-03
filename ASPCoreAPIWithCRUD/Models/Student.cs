using System;
using System.Collections.Generic;

namespace ASPCoreAPIWithCRUD.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public decimal? Gpa { get; set; }
        public int Tier { get; set; }
    }
}
