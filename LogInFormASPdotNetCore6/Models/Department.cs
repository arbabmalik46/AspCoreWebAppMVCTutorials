using System;
using System.Collections.Generic;

namespace LogInFormASPdotNetCore6.Models
{
    public partial class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int DepartmentCount { get; set; }
        public string DepartmentHead { get; set; } = null!;
        public string? DepartmentBuilding { get; set; }
        public string? DepartmentCity { get; set; }
        public int? DepartmentPostalCode { get; set; }
    }
}
