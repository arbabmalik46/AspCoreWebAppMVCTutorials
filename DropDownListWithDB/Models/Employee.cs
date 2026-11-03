using System;
using System.Collections.Generic;

namespace DropDownListWithDB.Models
{
    public partial class Employee
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Position { get; set; } = null!;
        public Guid CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
    }
}
